using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Passengers : MonoBehaviour
{
    public static Passengers instance;
    public float speed;
    public bool collidedWithDoor = false;
    public byte Green;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
     //if we press down on screen just move the passengers toward the door collider till we did not unpress the screen 
     //after colliding to door collder change movement toward inboard collider which is present inside of train
     //after colliding with inboard collider remove or set deactive this script so they can able fill like crowd
        if (Input.GetMouseButton(0) && Vehicle.instance.isReached)
        {
                float step = speed * Time.deltaTime;
                if (!collidedWithDoor && !Vehicle.instance.mouseUp)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterDoorCollider.position, step);
                }
                if (collidedWithDoor && !Vehicle.instance.mouseUp)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterInboarPosition.position, step);
                }  
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //setting after colliding with door add game object in the list and set parent to charecter container.
        if (other.gameObject.CompareTag("door"))
        {
            collidedWithDoor = true;
            

            transform.parent = GameManager.instance.CharecterContainer;

            foreach (Transform child in GameManager.instance.CharecterContainer.transform)
            {
                if (!GameManager.instance.colliderList.Contains(child.gameObject))
                {
                    GameManager.instance.colliderList.Add(child.gameObject);
                }
            }
            //if list of passenger is increse by maximum passenger count start changing color to red and start expanding
            if (GameManager.instance.colliderList.Count > GameManager.instance.maxPassengersLoad)
            {
                GameManager.instance.colorChangeDecrese();
                GameManager.instance.trainSizeIncreaser();
            }

        }
        //if we collide with charecter container which inside of train just destroy this script
        if(other.gameObject.CompareTag("Character Container")){
            StartCoroutine(PassengersSecondScript.instance.freezPos());
            Destroy(GetComponent<Passengers>());
        }


    }

}
