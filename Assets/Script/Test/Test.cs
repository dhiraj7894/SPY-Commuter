using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject side;

    public static Test instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }



    public void colorChage(float H, float S, float V, float A)
    {
        side.GetComponent<Renderer>().material.color = new Color(H, S, V, A);
        
    }
}
