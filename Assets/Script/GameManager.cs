using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Locations of targets")]
    public Transform CarTargetPosition1;
    public Transform CarTargetPosition2;
    public Transform characterDoorCollider;
    public Transform characterInboarPosition;
    public Transform BeforeInboardCharacters;
    public Transform CharecterContainer;
    public Transform CityPosition;
    
    [Header("Prefebs")]
    public GameObject City;

    [Header("Game Objects")]
    public GameObject DoorSide;
    public GameObject RightSide;
    public GameObject LeftSide;
    public GameObject BaseSide;
    public GameObject UPside;
    public GameObject sideCollider;
    public GameObject bomb;
    public GameObject plateformCollider;
    public GameObject OtherCompartments_1;
    public GameObject OtherCompartments_2;
    public GameObject Vehicale;


    [Header("Float Veriables")]
    public float xMaxPos;
    public float xMinPos;
    public float zMinPos;
    public float zMaxPos;
    public float colorChangeSpeed;
    public float scaleSpeed;
    public float gravityScale;

    [Header("Int Veriables")]
    public int PassengersCount;
    public int maxPassengersLoad;
    public int explodeTrainCount;

    [SerializeField]
    float Gr = 1;
    float Bl = 1;
    float scale = 3;
    float scale2 = 0;

    [Header("List or Arrays")]
    public List<GameObject> colliderList;
    public Transform[] characterSet1Position;
    public GameObject[] CharectersPrefeb;
    public GameObject[] SizeIncreaser;

    bool calOnce = false;

    void Start()
    {
        SizeIncreaser[0].transform.localScale = new Vector3(3, 0, 0);
        SizeIncreaser[1].transform.localScale = new Vector3(1, 0, 0);
        SizeIncreaser[2].transform.localScale = new Vector3(1, 0, 0);
        instance = this;
        plateformCollider.SetActive(true);
        CharecterSpawn();
        Gr = 1;
        Bl = 1;
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
            if (SizeIncreaser[1].transform.localScale.x > 2.5f)
            {
                SizeIncreaser[1].transform.localScale = new Vector3(2.5f, 0, 0);
                SizeIncreaser[2].transform.localScale = new Vector3(2.5f, 0, 0);
            }
        }

        if (Vehicle.instance.checkExplosion)
        {
            Destroy(UPside);
        }
    }
    public void CharecterSpawn()
    {
        Instantiate(City, CityPosition.position, Quaternion.Euler(0,0,0));

        for (int i = 0; i < PassengersCount; i++)
        {
            float xPosition = Random.Range(xMinPos, xMaxPos);
            float zPosition = Random.Range(zMinPos, zMaxPos);
            int characterPrefeb = Random.Range(0, 8);
            GameObject clone = Instantiate(CharectersPrefeb[characterPrefeb], new Vector3(xPosition, 10f, zPosition), Quaternion.identity);
            clone.transform.parent = BeforeInboardCharacters;
            
        }
            
       
    }
    public void vehicleExpo()
    {
        if (!Vehicle.instance.isExplode)
        {
            DoorSide.GetComponent<Rigidbody>().isKinematic = false;
            RightSide.GetComponent<Rigidbody>().isKinematic = false;
            LeftSide.GetComponent<Rigidbody>().isKinematic = false;
            BaseSide.GetComponent<Rigidbody>().isKinematic = false;
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
    public void callOnce()
    {
        Destroy(DoorSide, 1f);
        Destroy(LeftSide, 1f);
        Destroy(RightSide, 1f);
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

}
