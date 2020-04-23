﻿using System.Collections;
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
    float startTime;
    public bool doorClosed = false, isReached = false, checkExplosion = false, isExplode = false;

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        startTime = Time.time;
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
        if (GameManager.instance.colliderList.Count >= 30)
        {
            float scaleSpeedMesh = GameManager.instance.colliderList.Count;

            scale = scale2 = transform.localScale;
            scale.x = scale.z = 1+(scaleSpeedMesh/1000);
            transform.localScale = scale;
            GameManager.instance.colorChange();
            
        }
        if (GameManager.instance.colliderList.Count >= 45)
        {
            isExplode = true;
            GameManager.instance.vehicleExpo();
            Explode.instance.explode();
            yield return new WaitForSeconds(0.5f);
            Rigidbody r = GameManager.instance.door.GetComponent<Rigidbody>();
            r.freezeRotation = true;

        }

    }


}
