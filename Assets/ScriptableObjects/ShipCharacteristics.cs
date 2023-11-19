using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShipCharacteristics : ScriptableObject
{

    public Queue<Commands> CommandsQueue;
    public float speed;
    public float rotationSpeed;
    public float health;
    public float carryingCapacity;
    public float level;
    public float maximumFuel;
    public float currentFuel;
    
    
}
