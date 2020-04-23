﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charactersSet2 : MonoBehaviour
{
    public static charactersSet2 instance;
    
    
    public float speed;
    
    
    bool doorCheck = false;



    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Vehicle.instance.isReached)
        {
            float step = speed * Time.deltaTime;
            if (!doorCheck)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterDoorCollider.position, step);
            }
            if (doorCheck)
            {
                    transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterContainer2.position, step);
                

                
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("door"))
        {
            doorCheck = true;
            
        }
        if(other.gameObject.CompareTag("Character Container")){
            transform.parent = GameManager.instance.characterContainer2;
            foreach (Transform child in other.transform)
            {
                if (!GameManager.instance.colliderList.Contains(child.gameObject))
                {
                    GameManager.instance.colliderList.Add(child.gameObject);
                    gameObject.layer = LayerMask.NameToLayer("Default");
                    Destroy(GetComponent<charactersSet2>(), 0.3f);
                }
            }
        }
    }
}