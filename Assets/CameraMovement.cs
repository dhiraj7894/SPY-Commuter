using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        if (Vehicle.instance.citySpwaned)
        {
            //transform.position = new Vector3(transform.position.z, transform.position.y, speed *Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if(transform.position.z <= -220)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -220);
        }
        if(transform.position.z <= 0)
        {
            GameManager.instance.cameraScreen.SetActive(true);
        }
        if (transform.position.z <= -210)
        {
            GameManager.instance.cameraScreen.SetActive(false);
        }
    }
}
