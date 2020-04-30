using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotationActive : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vehicle.instance.isExplode)
        {
            rb.freezeRotation = false;
        }
    }
}
