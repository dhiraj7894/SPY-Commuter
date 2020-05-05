using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public GameObject sideCollider;

    [Header("Plateform")]
    public GameObject plateformCollider;

    [Header("Stations")]
    public GameObject[] stations;

    [Header("TextMeshPro")]
    public GameObject PerfectPrefeb;
    public GameObject ExplodePrefeb;

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

    [Header("Car Speed")]
    public float carSpeed;

    [Header("Float values for modification")]
    public float colorChangeSpeed;
    public float scaleSpeed;
    public float GravityOfPassengers;

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
    float scale = 2.5f;
    float scale2 = 0.5f;



    bool calOnce = false;
    bool charecterSpwanned = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        instance = this;

        //Set the 2nd position for train 
        TrainTargetPosition2.transform.position = TrainTargetPos[0];

        //set plateform collider true so passenger cannot able to fall on track
        plateformCollider.SetActive(true);
        cameraScreen.SetActive(false);

        //Spawn passengers
        CharecterSpawn();

        //spwan plateform PlateformSpwan(station to spwan, at which position vector3)
        PlateformSpwan(0, 0);

        //spwan city CitySpwan(City to spwan, City to spwan at which position Vector3)
        CitySpwan(0, 0);

        
        //Set default size of train expander sphere
        SizeIncreaser[0].transform.localScale = new Vector3(3, 0, 0);
        SizeIncreaser[1].transform.localScale = new Vector3(1, 0, 0);
        SizeIncreaser[2].transform.localScale = new Vector3(1, 0, 0);

        //set default color of train to R,G,P
        Gr = 1; //Green value 1
        Bl = 1; //Blue value 1

        //train left & right sides to set active when train explodes because if We don't add this we can not able to see 
        //whether trains sides are exploding or not
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

        //Set middle train expander to a maximum size
        if (!Vehicle.instance.isExplode)
        {
            if (SizeIncreaser[0].transform.localScale.x > 5.5f)
            {
                SizeIncreaser[0].transform.localScale = new Vector3(5.5f, 0, 0);
            }

        }

        //Destroy upper collider of train in which compartment the passengers are getting in
        if (Vehicle.instance.checkExplosion)
        {
            Destroy(UPside);
        }
    }
    public void CharecterSpawn()
    {
        for (int i = 0; i < PassengersCount; i++)
        {
            //select random position from given bound 
            float xPosition = Random.Range(xMinPos, xMaxPos);
            float zPosition = Random.Range(zMinPos, zMaxPos);

            //select random charechter from given number
            int characterPrefeb = Random.Range(0, 8);

            //Spwan passengers and set parent to container
            GameObject clone = Instantiate(CharectersPrefeb[characterPrefeb], new Vector3(xPosition, 6f, zPosition), Quaternion.identity);
            clone.transform.parent = BeforeInboardCharacters; 
        }
    }

    //platefomr spwanner
    public void PlateformSpwan(int stationNumber, int positionNumber)
    {
        Instantiate(stations[stationNumber], plateformPosition[positionNumber], Quaternion.Euler(0, -90, 0));
    }
    //city spwanner
    public void CitySpwan(int cityNumber, int cityposition)
    {
        GameObject clone = Instantiate(City[cityNumber], cityPosition[cityposition], Quaternion.Euler(0, 0, 0));
    }


    public void vehicleExpo()
    {
        if (!Vehicle.instance.isExplode)
        {
            //set Kinematic off of sides of train when train explode so all can able to animate explosion
            DoorSide.GetComponent<Rigidbody>().isKinematic = false;
            RightSide.GetComponent<Rigidbody>().isKinematic = false;
            LeftSide.GetComponent<Rigidbody>().isKinematic = false;
            BaseSide.GetComponent<Rigidbody>().isKinematic = false;
            sideCollider.GetComponent<Rigidbody>().isKinematic = false;
            SideExplode_1.GetComponent<Rigidbody>().isKinematic = false;
            SideExplode_2.GetComponent<Rigidbody>().isKinematic = false;

            bomb.GetComponent<Rigidbody>().isKinematic = false;

            //set MeshRenderer true of back side of train
            MeshRenderer m = sideCollider.GetComponent<MeshRenderer>();
            m.enabled = true;
        }

    }

    //coloer changing
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
        //decresing the green value so it should turn into red which is going to render on sides of trains
        Gr -= colorChangeSpeed;

        colorChange(Gr, Bl);
    }
    public void trainSizeIncreaser()
    {
        if (!Vehicle.instance.isExplode)
        {
            //here we are scallig the size of sphere colliders so our train can able to expands like it getting load burden
            scale += scaleSpeed;//starting size will be 3
            scale2 += scaleSpeed;//starting size will be 1

            SizeIncreaser[0].transform.localScale = new Vector3(transform.localScale.x + scale, 0, 0);
            SizeIncreaser[1].transform.localScale = new Vector3(transform.localScale.x + scale2, 0, 0);
            SizeIncreaser[2].transform.localScale = new Vector3(transform.localScale.x + scale2, 0, 0);
        }
            
    }

    //I given the name callOnce because under this method every line will call once if our train get explode
    public void callOnce()
    {
        //spwanning explode object after explosion
        GameObject overloaded = Instantiate(ExplodePrefeb, new Vector3(-11.05f,30, 10), Quaternion.Euler(15, 90, 0));
        overloaded.transform.parent = TMP;
        
        //start restart panal for restart button
        StartCoroutine(restartLevelPanal());

        //set sides to active so it can be visible they are getting hitted by explosion
        SideExplode_1.SetActive(true);
        SideExplode_2.SetActive(true);

        //after bit of time destroy previous sides so our new sides can be visible clearly
        Destroy(LeftSide,0.1f);
        Destroy(RightSide, 0.1f);

        //destroy all train side after 1 second
        Destroy(DoorSide, 1f);
        Destroy(SideExplode_1, 1);
        Destroy(SideExplode_2, 1);
        Destroy(sideCollider, 1);

        //destroy size increser as well but 0.5 second before sides
        Destroy(SizeIncreaser[0], 0.5f);
        Destroy(SizeIncreaser[1], 0.5f);
        Destroy(SizeIncreaser[2], 0.5f);

        //other two caprtement which is unusable but they will also be hitted by explosion so make Kinematic false
        OtherCompartments_1.GetComponent<Rigidbody>().isKinematic = false;
        OtherCompartments_2.GetComponent<Rigidbody>().isKinematic = false;

        // set trigger because objects are getting destroy after  1 sec
        LeftSide.GetComponent<Collider>().isTrigger = true;
        RightSide.GetComponent<Collider>().isTrigger = true;
        DoorSide.GetComponent<Collider>().isTrigger = true;
        BaseSide.GetComponent<Collider>().isTrigger = true;

        //set bool true so upper code line do not call again
        calOnce = true;
    }

   //Show Rstart panal after 1.5 second
    public IEnumerator restartLevelPanal()
    {
        yield return new WaitForSeconds(4f);
        LevelManager.instance.GameOverPanal.SetActive(true);
        LevelManager.instance.RestartLevel.SetActive(true);
    }


    //This will use is we spwan marine line station
/*
    public void charecterOnMarine()
    {
        if (Vehicle.instance.citySpwaned && !charecterSpwanned)
        {
            for (int i = 0; i < PassengersCount; i++)
            {
                float xPosition = Random.Range(xMinPosM, xMaxPosM);
                float zPosition = Random.Range(zMinPosM, zMaxPosM);
                int characterPrefeb = Random.Range(0, 8);
                GameObject clone = Instantiate(CharectersPrefeb[characterPrefeb], new Vector3(xPosition, 10f, zPosition), Quaternion.identity);
                clone.transform.parent = BeforeInboardCharacters;
            }
            charecterSpwanned = true;
        }
    }*/
}
