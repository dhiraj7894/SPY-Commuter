using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public List<GameObject> bone_list = new List<GameObject>();

    //[SerializeField]
    private float speed = 1f;
    public float data;
    private void Start()
    {
            foreach (Transform child in transform)
            {
                bone_list.Add(child.gameObject);
            }

        setPosition();
    }


    private void setPosition()
    {
        bone_list[0].transform.position = new Vector3(0, 0.11f, 0);
    }

}
