using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    #region Initialization
    public static Vehicle instance;
    #endregion
    public Rigidbody rb;
    public Animator animator;


    public float speed;
    public bool doorClosed = false, isReached = false;
    public float Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y, -40);
    }


    void FixedUpdate()
    {
        if (!doorClosed)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.CarTargetPosition1.position, speed * Time.deltaTime);
        }
        
        if (doorClosed)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.CarTargetPosition2.position, speed * Time.deltaTime);
        }

        if (transform.position == GameManager.instance.CarTargetPosition1.position)
        {
            isReached = true;
            StartCoroutine(reched());
        }
        
    }
    
    IEnumerator reched()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isReached", true);

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isReached", false);
            yield return new WaitForSeconds(1f);
            doorClosed = true;
        }
        if (GameManager.instance.colliderList.Count >= 10)
        {
            //Animation for destroy after overloading of charecters
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Passenger")) ;
    }


}
