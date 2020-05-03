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
        //**currently this line of Code is unused after spwanning marine line camera**
        //will change it's postion to marine line view

        if (Vehicle.instance.citySpwaned)
        {
            //set active camera view during train gose to next station currently showing a white image
            GameManager.instance.cameraScreen.SetActive(true);

            StartCoroutine(cameraPosChange());
        }
        
    }


    IEnumerator cameraPosChange()
    {
        yield return new WaitForSeconds(0.8f);
        if (nextPosition != null)
        {
            //selecting vector3 positon from inpector.
            transform.position = nextPosition[0];
        }  
        
    }
}
