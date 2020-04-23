using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform CarTargetPosition1, CarTargetPosition2, characterDoorCollider, characterContainer, characterContainer2, characters;
    public GameObject character1Prefeb, bomb, character2Prefeb;

    public GameObject door, side, side1, sideCollider;



    public Color endColor, startColor;
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
}
