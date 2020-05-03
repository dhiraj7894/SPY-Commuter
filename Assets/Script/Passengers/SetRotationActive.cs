using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotationActive : MonoBehaviour
{
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vehicle.instance.isExplode)
        {
            //set rotation false so passenger can rotate during falling from the explosion
            rb.freezeRotation = false;

            //increase gravity by multiplying he rigibody mass
            rb.AddForce(Physics.gravity * rb.mass);
        }
    }
}
