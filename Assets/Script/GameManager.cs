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
    public Transform characterContainer;
    public Transform characters;
    public Transform CityPosition;
    
    [Header("Prefebs")]
    public GameObject City;

    [Header("Game Objects")]
    public GameObject side2;
    public GameObject side;
    public GameObject side1;
    public GameObject sideCollider;
    public GameObject bomb;
    public GameObject plateformCollider;
    

    [Header("Float Veriables")]
    public float xMaxPos;
    public float xMinPos;
    public float zMinPos;
    public float zMaxPos;
    public float colorChangeSpeed;
    public float scaleSpeed;

    [Header("Int Veriables")]
    public int PassengersCount;
    public int maxPassengersLoad;
    public int explodeTrainCount;

    [SerializeField]
    float Gr = 1;
    float Bl = 1;
    float scale = 3;
    float scale2 = 1;

    [Header("List or Arrays")]
    public List<GameObject> colliderList;
    public Transform[] characterSet1Position;
    public GameObject[] CharectersPrefeb;
    public GameObject[] SizeIncreaser;

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
       // SP.radius = 1;
    }

    // Update is called once per frame
    public void CharecterSpawn()
    {
        Instantiate(City, CityPosition.position, Quaternion.Euler(0,136,0));

        for (int i = 0; i < PassengersCount; i++)
        {
            float xPosition = Random.Range(xMinPos, xMaxPos);
            float zPosition = Random.Range(zMinPos, zMaxPos);
            int characterPrefeb = Random.Range(0, 8);
            GameObject clone = Instantiate(CharectersPrefeb[characterPrefeb], new Vector3(xPosition, 10f, zPosition), Quaternion.identity);
            clone.transform.parent = characters;
            
        }
            
       
    }
    public void vehicleExpo()
    {
        side2.GetComponent<Rigidbody>().isKinematic = false;
        side.GetComponent<Rigidbody>().isKinematic = false;
        side1.GetComponent<Rigidbody>().isKinematic = false;
        bomb.GetComponent<Rigidbody>().isKinematic = false;
        sideCollider.GetComponent<Rigidbody>().isKinematic = false;
        MeshRenderer m = sideCollider.GetComponent<MeshRenderer>();
        m.enabled = true;
    }
    public void colorChange(float G,float B)
    {
        side.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
        side1.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
        sideCollider.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
        side2.GetComponent<Renderer>().material.color = new Color(1, G, B, 1);
    }
    public void colorChangeDecrese()
    {
        Bl = 0;
        Gr -= colorChangeSpeed;
        colorChange(Gr, Bl);
    }
    public void trainSizeIncreaser()
    {
        scale += scaleSpeed;
        scale2 += scaleSpeed;
        SizeIncreaser[0].transform.localScale = new Vector3(transform.localScale.x + scale, 0, 0);
        SizeIncreaser[1].transform.localScale = new Vector3(transform.localScale.x + scale2, 0, 0);
        SizeIncreaser[2].transform.localScale = new Vector3(transform.localScale.x + scale2, 0, 0);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
