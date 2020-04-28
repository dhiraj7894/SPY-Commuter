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
    public Transform characterContainer2;
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

    [Header("Int Veriables")]
    public int PassengersCount;
    public int maxPassengersLoad;
    public int explodeTrainCount;


    float Gr = 1, Bl = 1;

    [Header("List or Arrays")]
    public List<GameObject> colliderList;
    public Transform[] characterSet1Position;
    public GameObject[] CharectersPrefeb;
    void Start()
    {
        instance = this;
        plateformCollider.SetActive(true);
        CharecterSpawn();
        Gr = 1;
        Bl = 1;
        
    }
    private void Update()
    {
        
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
        Gr -= 0.1f;
        colorChange(Gr, Bl);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
