using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Ship/DefaultShipState")]
public class DefaultShipState : State<ShipController>
{
    
    public override void ChangeState()
    {
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
        if (!Parent.HasGoal) return;
        if (Vector3.Distance(Parent.transform.position, Parent.characteristics.homeDestination) < 0.2)
        {
            // It sets the next destination as the goal destination
            Parent.NextDestination = Parent.CurrentContract.TargetDestination;
            
            // it sets the ship as a regular NON-Return Trip
            Parent.IsReturnTrip = false;
            if (Parent.IsFlipped)
            {
                Parent.Flip();
            }
        }
        Parent.SetState(typeof(MoveShipSate));
    }
    
}

