using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform CarTargetPosition1, CarTargetPosition2, characterDoorCollider, characterContainer, characters;
    public GameObject characterPrefeb;
    public List<GameObject> colliderList;
    public Transform[] characterPosition;
    void Start()
    {
        instance = this;

        CharecterSpawn();
    }

    // Update is called once per frame
    public void CharecterSpawn()
    {
        for (int i = 0; i <= characterPosition.Length - 1; i++)
        {
            GameObject clone = Instantiate(characterPrefeb, characterPosition[i].position, Quaternion.identity);
            clone.transform.parent = characters;
        }
    }
}
