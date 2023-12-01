using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static PlayerInformation Instance;

    private void Awake()
    {
        if (Instance != this)
        {

            Debug.Log("");
        }
        else
        {
            Instance = this;
        }
    }
}
