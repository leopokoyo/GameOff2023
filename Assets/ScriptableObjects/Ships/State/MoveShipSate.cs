using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public abstract class MoveShipSate : State<ShipController>
{
    private float _current;
    public void HandleCommands()
    {
        
    }
    public override void ChangeState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

    public override void NewDay()
    {
        throw new System.NotImplementedException();
    }
}
