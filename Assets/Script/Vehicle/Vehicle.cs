using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    #region Initialization
    public static Vehicle instance;
    #endregion

    public Animator animator;
    public float Green;

    public float speed;
    public float StartPosition;
    public bool mouseUp = false, isReached = false, checkExplosion = false, isExplode = false, PerfectTextPopUp = false, citySpwaned = false;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition);

    }


    void FixedUpdate()
    {
        
        if (!mouseUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.CarTargetPosition1.position, speed * Time.deltaTime);
        }

        if (mouseUp)
        {
            if (!isExplode)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.CarTargetPosition2.position, speed * Time.deltaTime);
            } 
        }

        if (transform.position == GameManager.instance.CarTargetPosition1.position)
        {
            GameManager.instance.plateformCollider.GetComponent<Collider>().isTrigger = true;
            isReached = true;
            StartCoroutine(reched());
        }
        if(mouseUp && !isExplode)
        {
            if(GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad && !PerfectTextPopUp)
            {
                Instantiate(GameManager.instance.PerfectPrefeb, new Vector3(-11.05f, 30, 10), Quaternion.Euler(15, 90, 0));
                PerfectTextPopUp = true;
            }

            if (transform.position.z <= -40 && !citySpwaned)
            {
                GameManager.instance.PlateformSpwan(1, 1);
                GameManager.instance.CitySpwan(1, 1);
                citySpwaned = true;
            }
        }
        
    }


    IEnumerator reched()
    {
        //yield return new WaitForSeconds(0.5f);
        //animator.SetBool("isReached", true);

        if (Input.GetMouseButtonUp(0))
        {
            //animator.SetBool("isReached", false);
            yield return new WaitForSeconds(0.5f);
            mouseUp = true;
        }
        if (GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad)
        {
            checkExplosion = true;
        }
        if (GameManager.instance.colliderList.Count >= GameManager.instance.explodeTrainCount)
        {
            Green = 0;
            GameManager.instance.colorChange(Green,0f);
            GameManager.instance.vehicleExpo();
            isExplode = true;
            Explode.instance.explode();
        }

    }


}
