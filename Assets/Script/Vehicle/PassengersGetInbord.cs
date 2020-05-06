using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersGetInbord : MonoBehaviour
{
    //public Rigidbody rb;
    public Transform target;
    public float speedModifire = 10;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        GetComponent<Collider>().enabled = false;
        //GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vehicle.instance.PerfectTextPopUp)
        {
            GetComponent<Collider>().enabled = true;
            //GetComponent<Collider>().isTrigger = false;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speedModifire*Time.fixedDeltaTime);
        }
    }
}
