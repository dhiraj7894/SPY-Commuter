using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Vector3[] nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()  
    {
        if(Vehicle.instance.citySpwaned)
        {
            GameManager.instance.cameraScreen.SetActive(true);
            StartCoroutine(cameraPosChange());
        }
        if (transform.position.z <= nextPosition[0].z)
        {
            GameManager.instance.cameraScreen.SetActive(false);
        }
    }
    IEnumerator cameraPosChange()
    {
        yield return new WaitForSeconds(0.8f);
        if (nextPosition != null)
        {
            transform.position = nextPosition[0];
        }  
        
    }
}
