using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeContract
{
    public List<ICommand> Commands;
    public Vector3 TargetDestination;

    public TradeContract(Vector3 location, List<ICommand> commands)
    {
        Commands = commands;
        TargetDestination = location;
    }
    
}
