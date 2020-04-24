using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    #region Initialization
    public static Vehicle instance;
    #endregion

    public Animator animator;

    public Vector3 scale, scale2;

    public float Green;

    public float speed, scaleSpeed = 0.01f;
    public bool doorClosed = false, isReached = false, checkExplosion = false, isExplode = false;

    public float test;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
            if (!isExplode)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.CarTargetPosition2.position, speed * Time.deltaTime);
            } 
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
        if (GameManager.instance.colliderList.Count >= 50)
        {
            float scaleSpeedMesh = GameManager.instance.colliderList.Count;
            
            //animator.SetTrigger("isOverload");
            //scale = transform.localScale;
            //scale.x = scale.z = 1+(scaleSpeedMesh/1000);
            //transform.localScale = scale;

        }
        if (GameManager.instance.colliderList.Count >= 60)
        {
            Green = 0;
            GameManager.instance.colorChange(Green,0f);
            isExplode = true;
            GameManager.instance.vehicleExpo();
            Explode.instance.explode();
            yield return new WaitForSeconds(0.5f);
            Rigidbody r = GameManager.instance.side2.GetComponent<Rigidbody>();
            r.freezeRotation = true;

        }

    }


}
