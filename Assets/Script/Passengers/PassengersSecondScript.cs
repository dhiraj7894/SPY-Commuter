using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengersSecondScript : MonoBehaviour
{
    Rigidbody rb;
    bool rotationFreez = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (Vehicle.instance.isExplode && !rotationFreez)
        {
            //set rotation false so passenger can rotate during falling from the explosion
            rb.freezeRotation = false;
            rotationFreez = true;


        }
        if (Vehicle.instance.isExplode)
        {
            //increase gravity by multiplying he rigibody mass
            rb.AddForce(Physics.gravity * rb.mass);
        }
            if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Vehicle.instance.isExplode && rotationFreez)
        {
            if (collision.gameObject.CompareTag("plateform"))
            {
                gameObject.tag = "plateform";
                StartCoroutine(freez());
            }
        }
    }
    IEnumerator freez()
    {
        yield return new WaitForSeconds(0.5f);
        //rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.freezeRotation = true;
        Destroy(gameObject, 4f);
    }
}
