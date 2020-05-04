using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanScripManager : MonoBehaviour
{
    public static SpwanScripManager instance;

    //[Header("Car position")]
    private void Start()
    {
        instance = this;

    }
}
