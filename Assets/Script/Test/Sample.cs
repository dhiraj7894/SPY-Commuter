using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // public List<GameObject> bone_list = new List<GameObject>();

    public GameObject DoorBoneStart;
    public GameObject RightBoneStart;
    public GameObject LeftBoneStart;
    public GameObject DoorBoneEnd;
    public GameObject RightBoneEnd;
    public GameObject LeftBoneEnd;

    Vector3 doorStartBone;
    Vector3 rightStartBone;
    Vector3 leftStartBone;
    Vector3 doorEndBone;
    Vector3 rightEndBone;
    Vector3 leftEndBone;


    private void FixedUpdate()
    {
        /*if (Vehicle.instance.isReached)
        {
             doorStartBone = DoorBoneStart.transform.position;
             doorEndBone = DoorBoneEnd.transform.position;

            rightStartBone = RightBoneStart.transform.position;
            rightEndBone = RightBoneEnd.transform.position;

            leftStartBone = LeftBoneStart.transform.position;
            leftEndBone = LeftBoneEnd.transform.position;
        }

        if (Vehicle.instance.checkExplosion && !Vehicle.instance.isExplode)
        {
            DoorBoneStart.transform.position = doorStartBone;
            DoorBoneEnd.transform.position = doorEndBone;

            RightBoneStart.transform.position = rightStartBone;
            RightBoneEnd.transform.position = rightEndBone;

            LeftBoneStart.transform.position =  leftStartBone;
            LeftBoneEnd.transform.position = leftEndBone;
        }*/
    }
}
