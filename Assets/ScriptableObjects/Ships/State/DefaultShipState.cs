using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Ship/DefaultShipState")]
public class DefaultShipState : State<ShipController>
{

    private float _current;

    public override void ChangeState()
    {
        if (!Parent.characteristics.hasGoal) return;
        if (Parent.characteristics.nextDestination != Parent.characteristics.position)
        {
            Parent.SetState(typeof(MoveShipSate));
        }
    }

    public override void ExitState()
    {
        Debug.Log("MOVE FROM IDLE");
    }

    public override void Update()
    {
        
    }

    public override void HandleInput()
    {
    }

    public override void NewDay()
    {
        
    }
    
}

