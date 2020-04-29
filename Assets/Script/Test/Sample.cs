using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // public List<GameObject> bone_list = new List<GameObject>();

    public GameObject BoneStart;
    public GameObject BoneEnd;

    
    public void SetPositin()
    {
        BoneEnd.transform.position = new Vector3(0, 0, 0);
        BoneStart.transform.position = new Vector3(0, 0, 0);
    }
}
