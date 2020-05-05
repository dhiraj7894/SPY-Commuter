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
        //in start of game set postion to start postion and start moveing towards station position

        instance = this;

        //Currently Unused**
        animator = GetComponent<Animator>();

        transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition);

    }


    void FixedUpdate()
    {
        if (!PerfectTextPopUp && !mouseUp)
        {
            //if mouse button is not true then just move the train towards the stations 
            //postion which is define by implementing a Traansform object
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.TrainTargetPosition1.position, speed * Time.fixedDeltaTime);
        }

        if (mouseUp || PerfectTextPopUp)
        {//if mouse is up and train haven't explode yet then just ran away from train
            if (!isExplode)
                StartCoroutine(startMovingTowardsSecondPosition());
            
        }

        //if we reached to station set plateform collider to trigger in so all passenger can able to walk in from door
        if (transform.position == GameManager.instance.TrainTargetPosition1.position)
        {
            GameManager.instance.plateformCollider.GetComponent<Collider>().isTrigger = true;
            isReached = true;
            StartCoroutine(reched());
        }

        if(!isExplode)
        {
            //let's show the UI if whether we completed this level or not
            //if we fill the train more then max capacity and leave before exploding the train 
            //then just pop up Perfect test on the train
            
            if (GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad  && GameManager.instance.colliderList.Count == GameManager.instance.PassengersCount && !PerfectTextPopUp)
            {
                Instantiate(GameManager.instance.PerfectPrefeb, new Vector3(-11.05f, 30, 10), Quaternion.Euler(15, 90, 0));
                StartCoroutine(ShowNextLevelPanal());
                PerfectTextPopUp = true;
            }
            if (mouseUp)
            {
                if (GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad && !PerfectTextPopUp)
                {
                    Instantiate(GameManager.instance.PerfectPrefeb, new Vector3(-11.05f, 30, 10), Quaternion.Euler(15, 90, 0));
                    StartCoroutine(ShowNextLevelPanal());
                    PerfectTextPopUp = true;
                }

                //and if we fill less than max capacity even one, we need to restart that level
                if (GameManager.instance.colliderList.Count < GameManager.instance.maxPassengersLoad)
                {
                    StartCoroutine(GameManager.instance.restartLevelPanal());
                }
            }
           
        }
        
    }


    IEnumerator reched()
    {
        //if we unhold the screen after filling or during filling the train set boolen mouseUP to true so train move
        //toward scond position
        if (Input.GetMouseButtonUp(0))
        {
            yield return new WaitForSeconds(0.5f);
            mouseUp = true;
        }
        //if we cross the level of max capacity of train just set checkExplosion to true we can use it another code
        if (GameManager.instance.colliderList.Count >= GameManager.instance.maxPassengersLoad)
        {
            checkExplosion = true;
        }

        //if we exceed the limit of train and reach the explosion point 
        //just set train to red
        //set all collider false 
        //set boolen isExplode to true
        //at the end explode the train and throw all the passengers 
        if (GameManager.instance.colliderList.Count >= GameManager.instance.explodeTrainCount)
        {
            Green = 0;
            GameManager.instance.colorChange(Green,0f);
            GameManager.instance.vehicleExpo();
            isExplode = true;
            Explode.instance.explode();
        }

    }

    //if we call this function just show next level panal after 1.5 second
    IEnumerator ShowNextLevelPanal()
    {
        yield return new WaitForSeconds(2.5f);
        LevelManager.instance.GameOverPanal.SetActive(true);
        LevelManager.instance.NextLevel.SetActive(true);
    }

    //after 0.75 second start moveing away from train if level is paased or we haven't explode the train
    IEnumerator startMovingTowardsSecondPosition()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.TrainTargetPosition2.position, speed * Time.fixedDeltaTime);
    }

}
