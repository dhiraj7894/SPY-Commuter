using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform CarTargetPosition1, CarTargetPosition2, characterDoorCollider, characterContainer, characters/*, doorPosition, sidePosition, side1Position*/;
    public GameObject characterPrefeb/*, doorEffectPrefeb, sideEffectPrefeb, side1EffectPrefeb*/;
/*
    public GameObject door, side, side1;*/

    public List<GameObject> colliderList;
    public Transform[] characterPosition;
    void Start()
    {
        instance = this;

        CharecterSpawn();
/*        door.SetActive(true);
        side.SetActive(true);
        side1.SetActive(true);*/

    }
    private void Update()
    {
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
    public void vehicleExpo()
    {

    }
}
