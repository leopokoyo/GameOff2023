using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public EventInstance Ambience;
    public EventInstance Music;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Music = RuntimeManager.CreateInstance(FmodEvents.Instance.Music);
        Ambience = RuntimeManager.CreateInstance(FmodEvents.Instance.Ambience);

        Music.start();
        Ambience.start();
    }
}
