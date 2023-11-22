using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : StateRunner<ShipController>
{
    [SerializeField] internal ShipCharacteristics characteristics;
    

    private void Start()
    {
        Debug.Log(transform.position);
        characteristics.position = transform.position;
        Debug.Log(characteristics.position);
        SetState(typeof(DefaultShipState));
        MainEventBus.NextDay += OnNewDay;
    }

    private void OnEnable()
    {
        MainEventBus.NextDay += OnNewDay;
    }

    private void OnDisable()
    {
        MainEventBus.NextDay -= OnNewDay;
    }

    private void OnNewDay(object sender, int dayIndex)
    {
        _activeState.NewDay();
        Debug.Log("NewDay");
    }


}
