using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : StateRunner<ShipController>
{
    [SerializeField] internal ShipCharacteristics characteristics;
    private Animator _animator;

    internal Vector3 NextDestination;
    internal Vector3 GoalDestination;

    internal bool HasGoal;
    internal bool IsReturnTrip;
    internal bool IsFlipped;

    private void Start()
    {
        ChangePositionTest();
        _animator = GetComponent<Animator>();
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
    }


    public void Flip()
    {
        if (_animator.GetBool("isActive"))
        {
            _animator.SetBool("isActive", false);
        } else
        {
            _animator.SetBool("isActive", false);
        }
        
    }

    private void ChangePositionTest()
    {
        HasGoal = true;
        GoalDestination = new Vector3(20, 10, 0);
    }
}
