using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private ShipController _parent;
    
    public MoveCommand(ShipController parent)
    {
        _parent = parent;
    }
    
    public void Execute()
    {
    
       _parent.transform.position = Vector3.MoveTowards(_parent.characteristics.position,_parent.characteristics.nextDestination, _parent.characteristics.speed);
        
    }

    public void Init()
    {
    }
}
