using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region __init
    [Header("Train movement target")]
    public Transform TrainTargetPosition1;
    public Transform TrainTargetPosition2;

    [Header("Train movement position")]
    public float targetPosZ;

    [Header("Passenger target")]
    public Transform characterDoorCollider;
    public Transform characterInboarPosition;
    public Transform BeforeInboardCharacters;
    public Transform CharecterContainer;
    public Transform CityPosition;

    [Header("Other targets")]
    public Transform TMP;
    
    [Header("City to spwan")]
    public GameObject[] City;

    [Header("Trains Parts")]
    public GameObject DoorSide;
    public GameObject RightSide;
    public GameObject LeftSide;
    public GameObject BaseSide;
    public GameObject UPside;
    public GameObject bomb;
    public GameObject OtherCompartments_1;
    public GameObject OtherCompartments_2;
    public GameObject SideExplode_1;
    public GameObject SideExplode_2;

    [Header("Plateform")]
    public GameObject sideCollider;
    public GameObject plateformCollider;

    [Header("Stations")]
    public GameObject[] stations;

    [Header("TextMeshPro")]
    public GameObject PerfectPrefeb;
    public GameObject OverloadPrefeb;

    [Header("Canves")]
    public GameObject cameraScreen;

    [Header("Bound for Churchgate")]
    public float xMaxPos;
    public float xMinPos;
    public float zMinPos;
    public float zMaxPos;

    [Header("Bound for MarineLine")]
    public float xMaxPosM;
    public float xMinPosM;
    public float zMinPosM;
    public float zMaxPosM;

    [Header("Float values for modification")]
    public float colorChangeSpeed;
    public float scaleSpeed;

    [Header("Train Capacity and load")]
    public int PassengersCount;
    public int maxPassengersLoad;
    public int explodeTrainCount;

    [Header("List or Arrays")]
    public List<GameObject> colliderList;
    public GameObject[] CharectersPrefeb;
    public GameObject[] SizeIncreaser;

    [Header("Plateform Position")]
    public Vector3[] plateformPosition;
    public Vector3[] cityPosition;
    public Vector3[] TrainTargetPos;
    #endregion

    float Gr = 1;
    float Bl = 1;
    float scale = 3;
    float scale2 = 1f;



    bool calOnce = false;
    bool charecterSpwanned = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        instance = this;

        TrainTargetPosition2.transform.position = TrainTargetPos[0];

        plateformCollider.SetActive(true);
        cameraScreen.SetActive(false);

        CharecterSpawn();
        PlateformSpwan(0, 0);
        CitySpwan(0, 0);

        

        SizeIncreaser[0].transform.localScale = new Vector3(3, 0, 0);
        SizeIncreaser[1].transform.localScale = new Vector3(1, 0, 0);
        SizeIncreaser[2].transform.localScale = new Vector3(1, 0, 0);


        Gr = 1;
        Bl = 1;

        SideExplode_1.SetActive(false);
        SideExplode_2.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vehicle.instance.isExplode)
        {
            if (!calOnce)
            {
                callOnce();
            }
            
        }

        if (!Vehicle.instance.isExplode)
        {
            if (SizeIncreaser[0].transform.localScale.x > 5.5f)
            {
                SizeIncreaser[0].transform.localScale = new Vector3(5.5f, 0, 0);
            }

        }

        if (Vehicle.instance.checkExplosion)
        {
            Destroy(UPside);
        }
    }
    public void CharecterSpawn()
    {
        for (int i = 0; i < PassengersCount/3; i++)
        {
            float xPosition = Random.Range(xMinPos, xMaxPos);
            float zPosition = Random.Range(zMinPos, zMaxPos);
            int characterPrefeb = Random.Range(0, 8);
            GameObject clone = Instantiate(CharectersPrefeb[characterPrefeb], new Vector3(xPosition, 10f, zPosition), Quaternion.identity);

            clone.transform.parent = BeforeInboardCharacters; 
        }
    }

    public void PlateformSpwan(int stationNumber, int positionNumber)
    {
        Instantiate(stations[stationNumber], plateformPosition[positionNumber], Quaternion.Euler(0, -90, 0));
    }
    public void CitySpwan(int cityNumber, int cityposition)
    {
        GameObject clone = Instantiate(City[cityNumber], cityPosition[cityposition], Quaternion.Euler(0, 0, 0));
    }
    public void vehicleExpo()
    {
        if (!Vehicle.instance.isExplode)
        {
            DoorSide.GetComponent<Rigidbody>().isKinematic = false;
            RightSide.GetComponent<Rigidbody>().isKinematic = false;
            LeftSide.GetComponent<Rigidbody>().isKinematic = false;
            BaseSide.GetComponent<Rigidbody>().isKinematic = false;
            SideExplode_1.GetComponent<Rigidbody>().isKinematic = false;
            SideExplode_2.GetComponent<Rigidbody>().isKinematic = false;
            bomb.GetComponent<Rigidbody>().isKinematic = false;
            sideCollider.GetComponent<Rigidbody>().isKinematic = false;
            MeshRenderer m = sideCollider.GetComponent<MeshRenderer>();
            m.enabled = true;
        }

    }
    public void colorChange(float G,float B)
    {
        if (!Vehicle.instance.isExplode)
        {
            RightSide.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
            LeftSide.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
            sideCollider.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
            DoorSide.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
            SideExplode_1.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
            SideExplode_2.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);

        }
            
    }
    public void colorChangeDecrese()
    {
        Bl = 0;
        Gr -= colorChangeSpeed;
        colorChange(Gr, Bl);
    }
    public void trainSizeIncreaser()
    {
        if (!Vehicle.instance.isExplode)
        {
            scale += scaleSpeed;
            scale2 += scaleSpeed;
            SizeIncreaser[0].transform.localScale = new Vector3(transform.localScale.x + scale, 0, 0);
            SizeIncreaser[1].transform.localScale = new Vector3(transform.localScale.x + scale2, 0, 0);
            SizeIncreaser[2].transform.localScale = new Vector3(transform.localScale.x + scale2, 0, 0);
        }
            
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void callOnce()

    {
        GameObject overloaded = Instantiate(OverloadPrefeb, new Vector3(-11.05f,30, 10), Quaternion.Euler(15, 90, 0));
        overloaded.transform.parent = TMP;

        SideExplode_1.SetActive(true);
        SideExplode_2.SetActive(true);

        Destroy(DoorSide, 1f);
        Destroy(LeftSide,0.1f);
        Destroy(RightSide, 0.1f);
        Destroy(SideExplode_1, 1);
        Destroy(SideExplode_2, 1);
        Destroy(sideCollider, 1);

        Destroy(SizeIncreaser[0], 0.5f);
        Destroy(SizeIncreaser[1], 0.5f);
        Destroy(SizeIncreaser[2], 0.5f);

        OtherCompartments_1.GetComponent<Rigidbody>().isKinematic = false;
        OtherCompartments_2.GetComponent<Rigidbody>().isKinematic = false;

        LeftSide.GetComponent<Collider>().isTrigger = true;
        RightSide.GetComponent<Collider>().isTrigger = true;
        DoorSide.GetComponent<Collider>().isTrigger = true;
        BaseSide.GetComponent<Collider>().isTrigger = true;

        calOnce = true;
    }

    public void charecterOnMarine()
    {
        if (Vehicle.instance.citySpwaned && !charecterSpwanned)
        {
            for (int i = 0; i < PassengersCount / 2; i++)
            {
                float xPosition = Random.Range(xMinPosM, xMaxPosM);
                float zPosition = Random.Range(zMinPosM, zMaxPosM);
                int characterPrefeb = Random.Range(0, 8);
                GameObject clone = Instantiate(CharectersPrefeb[characterPrefeb], new Vector3(xPosition, 10f, zPosition), Quaternion.identity);
                clone.transform.parent = BeforeInboardCharacters;
            }
            charecterSpwanned = true;
        }
    }
}
