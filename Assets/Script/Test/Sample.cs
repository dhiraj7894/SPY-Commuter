using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // public List<GameObject> bone_list = new List<GameObject>();

    public GameObject BoneStart;
    public GameObject BoneEnd;
    Vector3 startBone;
    Vector3 endBone;


    private void FixedUpdate()
    {
        if (Vehicle.instance.isReached)
        {
             startBone = BoneStart.transform.position;
             endBone = BoneStart.transform.position;
        }

        if (Vehicle.instance.checkExplosion && !Vehicle.instance.isExplode)
        {
            BoneStart.transform.position = startBone;
            BoneEnd.transform.position = endBone;
        }
    }
}
