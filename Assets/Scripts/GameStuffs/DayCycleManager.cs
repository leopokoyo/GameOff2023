using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        InvokeRepeating("NewDay", 2,5);
    }

    private void NewDay()
    {
        MainEventBus.NextDay?.Invoke(this, 2);
    }
}
