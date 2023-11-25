using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu (menuName = "State/Ship/DockingShip")]
public class DockingShipState : State<ShipController>
{
    public override void ChangeState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void HandleInput()
    {
        
    }

    public override void NewDay()
    {
        // It sets it as a return trip
        Parent.IsReturnTrip = true;
        // If the ship's cur
        Parent.NextDestination = Parent.characteristics.homeDestination;
            
        // If the ship is not flipped it will flip it
        if (!Parent.IsFlipped)
        {
            Parent.Flip();
                
        }
        Parent.SetState(typeof(MoveShipSate));
    }
}
