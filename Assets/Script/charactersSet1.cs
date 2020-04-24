using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charactersSet1 : MonoBehaviour
{
    public static charactersSet1 instance;
    public float speed;
    bool isTagged = false;

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
            float step = speed * Time.deltaTime;
            if (!isTagged)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterDoorCollider.position, step);
            }
            if (isTagged)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterContainer.position, step);


            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("door"))
        {
            isTagged = true;

            if (GameManager.instance.colliderList.Count >= 50)
            {
                GameManager.instance.colorChangeDecrese();
            }

        }
        if(other.gameObject.CompareTag("Character Container")){
            transform.parent = GameManager.instance.characterContainer;
            foreach (Transform child in other.transform)
            {
                if (!GameManager.instance.colliderList.Contains(child.gameObject))
                {
                    GameManager.instance.colliderList.Add(child.gameObject);
                    gameObject.layer = LayerMask.NameToLayer("Default");
                    Destroy(GetComponent<charactersSet1>(), 0.3f);
                }
            }
        }
    }
}
