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
    
       _parent.transform.position = Vector3.MoveTowards(_parent.transform.position,_parent.NextDestination, _parent.characteristics.speed);
                    
    }                                                   
                    
    public void Init()
    {
    }
}
