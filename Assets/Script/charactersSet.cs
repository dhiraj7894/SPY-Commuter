using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class charactersSet : MonoBehaviour
{
    public static charactersSet instance;
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
            GameManager.instance.plateformCollider.SetActive(false);
            float step = speed * Time.deltaTime;
            if (!isTagged && !Vehicle.instance.mouseUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.characterDoorCollider.position, step);
            }
            if (isTagged && !Vehicle.instance.mouseUp)
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

            if (GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad)
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
                    Destroy(GetComponent<charactersSet>(), 0.3f);
                }
            }
        }
    }
}
