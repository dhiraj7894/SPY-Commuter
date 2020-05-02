using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charactersSet : MonoBehaviour
{
    public static charactersSet instance;
    public float speed;
    public bool isTagged = false;
    public byte Green;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        
        if (Input.GetMouseButton(0) && Vehicle.instance.isReached)
        {
            if(transform.position.z >= -30)
            {
                float step = speed * Time.deltaTime;
                if (!isTagged && !Vehicle.instance.mouseUp)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterDoorCollider.position, step);
                }
                if (isTagged && !Vehicle.instance.mouseUp)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterInboarPosition.position, step);
                }
            }
            if(Vehicle.instance.transform.position.z >= -220)
            {
                float step = speed * Time.deltaTime;
                if (!isTagged)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterDoorCollider.position, step);
                }
                if (isTagged)
                {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterInboarPosition.position, step);
                }
            }
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("door"))
        {
            isTagged = true;
            transform.parent = GameManager.instance.CharecterContainer;
            foreach (Transform child in GameManager.instance.CharecterContainer.transform)
            {
                if (!GameManager.instance.colliderList.Contains(child.gameObject))
                {
                    GameManager.instance.colliderList.Add(child.gameObject);
                }
            }
            if (GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad)
            {
                GameManager.instance.colorChangeDecrese();
                GameManager.instance.trainSizeIncreaser();
            }

        }
        if(other.gameObject.CompareTag("Character Container")){
            gameObject.layer = LayerMask.NameToLayer("Default");
            Destroy(GetComponent<charactersSet>());
        }


    }
}
