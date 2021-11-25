using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for not strees the computers xd
public class LimitFrameRate : MonoBehaviour
{
    public int targetFrameRate=75;
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }

   
}
