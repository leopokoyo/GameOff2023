using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu (menuName = "State/Ship/MoveShip")]
public class MoveShipSate : State<ShipController>
{
    public override void ChangeState()
    {
        if (Vector3.Distance(Parent.transform.position,Parent.NextDestination) > 0.2) return;
        
        // If the ship is returning then it goes to IDLE otherwise it goes to DOCKING
        Parent.SetState(!Parent.IsReturnTrip ? typeof(DockingShipState) : typeof(DefaultShipState));
    }

    public override void ExitState()
    {
        Debug.Log("EXITING MOVING STATE");
    }

    public override void Update()
    {

        Parent.transform.position = Vector3.MoveTowards(Parent.transform.position, Parent.NextDestination,Parent.characteristics.speed * Time.deltaTime);
    }

    public override void HandleInput()
    {
        
    }

    public override void NewDay()
    {
        
    }
}
