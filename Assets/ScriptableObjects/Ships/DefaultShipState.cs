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
        if (Vector3.Distance(Parent.characteristics.position, Parent.characteristics.nextDestination) < 2)
        {
            
        }
    }

    public override void ExitState()
    {
    }

    public override void Update()
    {

        if (Parent.characteristics.nextDestination != Parent.characteristics.position)
        {
            _current += Time.deltaTime;
            Parent.characteristics.position = Vector3.Lerp(Parent.characteristics.position,
                Parent.characteristics.nextDestination,
                 (Time.deltaTime * Parent.characteristics.speedCurve.Evaluate(_current))/ Parent.characteristics.speed);
            Parent.transform.position = Parent.characteristics.position;
        }
        else
        {
            _current = 0;
        }
        
    }

    public override void HandleInput()
    {
    }

    public override void NewDay()
    {
        
    }
    
}

