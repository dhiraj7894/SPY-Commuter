using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform CarTargetPosition1, CarTargetPosition2, characterDoorCollider, characterContainer, characterContainer2, characters/*, doorPosition, sidePosition, side1Position*/;
    public GameObject character1Prefeb, bomb, character2Prefeb;

    public GameObject door, side, side1, sideCollider;
    public float startTime;

    public Color endColor;
    public List<GameObject> colliderList;
    public Transform[] characterSet1Position, characterSet2Position;
    void Start()
    {
        instance = this;

        CharecterSpawn();


    }
    private void Update()
    {
    }

    // Update is called once per frame
    public void CharecterSpawn()
    {
        for (int i = 0; i <= characterSet1Position.Length - 1; i++)
        {
            GameObject clone = Instantiate(character1Prefeb, characterSet1Position[i].position, Quaternion.identity);
            clone.transform.parent = characters;
        }
        for (int i = 0; i <= characterSet2Position.Length - 1; i++)
        {
            GameObject clone = Instantiate(character2Prefeb, characterSet2Position[i].position, Quaternion.identity);
            clone.transform.parent = characters;
        }
    }
    public void vehicleExpo()
    {
        door.GetComponent<Rigidbody>().isKinematic = false;
        side.GetComponent<Rigidbody>().isKinematic = false;
        side1.GetComponent<Rigidbody>().isKinematic = false;
        bomb.GetComponent<Rigidbody>().isKinematic = false;
        sideCollider.GetComponent<Rigidbody>().isKinematic = false;
        MeshRenderer m = sideCollider.GetComponent<MeshRenderer>();
        m.enabled = true;
    }
    public void colorChange()
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Renderer doorR = door.GetComponent<Renderer>();
        Renderer sideR = side.GetComponent<Renderer>();
        Renderer side1R = side1.GetComponent<Renderer>();
        Renderer side2R = sideCollider.GetComponent<Renderer>();
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        float t = (Time.time - startTime) * 1f;
        doorR.material.color = Color.Lerp(doorR.material.color, endColor, t);
        sideR.material.color = Color.Lerp(sideR.material.color, endColor, t);
        side1R.material.color = Color.Lerp(side1R.material.color, endColor, t);
        side2R.material.color = Color.Lerp(side2R.material.color, endColor, t);
    }
}
