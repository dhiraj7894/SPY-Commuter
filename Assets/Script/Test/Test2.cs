using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public float H, S, V,A;
    // Start is called before the first frame update
    void Start()
    {
        H = 0;
        S = 0;
        V = 0;
        A = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            S -= 1;
            if(S >= 255f)
            {
                S = 255;
            }
        }
        Test.instance.colorChage(H,S,V,A);
    }
}
