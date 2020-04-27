using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    public List<GameObject> bone_list = new List<GameObject>();

    public float speed = 1f;
    private void Start()
    {
       /* int i=0;
        while (i== 0)
        {*/
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

                bone_list[1].transform.Rotate(transform.rotation.x * Time.deltaTime * speed, 0, 0);

    }

}
