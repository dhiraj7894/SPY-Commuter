using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSeen : MonoBehaviour
{
    public Transform test;
    public GameObject prefeb;

    bool isSpwanned = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSpwanned = true;
              
        }
        if (isSpwanned)
        {
            GameObject obj = Instantiate(prefeb, test.position, Quaternion.identity);
            //Destroy(obj, 0.2f);
            isSpwanned = false;
        }

    }

}
