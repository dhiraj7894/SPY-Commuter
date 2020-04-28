using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public List<GameObject> bone_list = new List<GameObject>();

    public float speed = 0.2f;
    private void Start()
    {
            foreach (Transform child in transform)
            {
                bone_list.Add(child.gameObject);
                foreach (Transform child1 in child)
                {
                    bone_list.Add(child1.gameObject);
                }
            }
        
        
    }


    private void Update()
    {

    }

}
