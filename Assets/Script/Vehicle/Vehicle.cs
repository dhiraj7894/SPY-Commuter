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


    public float speed, scaleSpeed = 0.01f;
    public bool doorClosed = false, isReached = false, checkExplosion = false, isExplode = false;
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
        if (GameManager.instance.colliderList.Count >= 10)
        {
            scale = scale2 = transform.localScale;
            scale.x = scale.z += scaleSpeed;
            scale2.x = scale2.z = 1.2f;

            if (scale.x <= 1.2f)
            {
                transform.localScale = scale;
            }
            if(scale.x>=1.2f)
            {
                transform.localScale = scale2;
            }
        }
        if(GameManager.instance.colliderList.Count >= 15)
        {
            isExplode = true;
            GameManager.instance.vehicleExpo();
            Explode.instance.explode();
        }

    }


}
