using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform CarTargetPosition1, CarTargetPosition2, characterDoorCollider, characterContainer, characterContainer2, characters;
    public GameObject[] Prefeb;

    public GameObject side2, side, side1, sideCollider, bomb;

    float Gr = 1, Bl = 1;
    public List<GameObject> colliderList;
    public Transform[] characterSet1Position/*, characterSet2Position*/;
    void Start()
    {
        instance = this;

        CharecterSpawn();
        Gr = 1;
        Bl = 1;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    public void CharecterSpawn()
    {
        for (int i = 0; i <= characterSet1Position.Length - 1; i++)
        {
            int characterPrefeb = Random.Range(0, 2);
            GameObject clone = Instantiate(Prefeb[characterPrefeb], characterSet1Position[i].position, Quaternion.identity);
            clone.transform.parent = characters;
        }
       /* for (int i = 0; i <= characterSet2Position.Length - 1; i++)
        {
            GameObject clone = Instantiate(character2Prefeb, characterSet2Position[i].position, Quaternion.identity);
            clone.transform.parent = characters;
        }*/
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
}
