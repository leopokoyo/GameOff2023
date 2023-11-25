using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Data/ShipData")]
[Serializable]
public class ShipCharacteristics : ScriptableObject
{

    public AnimationCurve speedCurve;
    public Vector3 nextDestination;
    public Vector3 goalDestination;
    public Vector3 homeDestination;
    public float speed;
    public float rotationSpeed;
    public float health;
    public float carryingCapacity;
    public float level;
    public float maximumFuel;
    public float currentFuel;
    public bool hasGoal;
    public bool isReturnTrip;
    


}
