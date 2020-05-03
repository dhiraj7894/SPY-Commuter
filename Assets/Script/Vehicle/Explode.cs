using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public static Explode instance;
    public float redius = 5f, force, upForce;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void explode()
    {
        //Collect all collider with this sphere is colliding in array
       Collider[] colliders =  Physics.OverlapSphere(transform.position, redius);
        //every each collider which are present nearby get component rigidbody and apply force 
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, redius, upForce, ForceMode.Impulse);
            }
        }
    }
}
