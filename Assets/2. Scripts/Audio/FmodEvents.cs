using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FmodEvents : MonoBehaviour
{
    
    public static FmodEvents Instance { get; private set;}
    
    [field: Header("Music")]
    [field: SerializeField]
    public EventReference Music { get; private set;}
    
    
    [field: Header("Ambience")]
    [field: SerializeField]
    public EventReference Ambience { get; private set;}

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;    
        }
    }
} 
