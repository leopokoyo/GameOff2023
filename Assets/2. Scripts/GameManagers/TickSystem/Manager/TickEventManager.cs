using System;
using GameManagers.TickSystem.Events;
using UnityEngine;

namespace GameManagers.TickSystem.Manager
{
    
    // HOLDER OF THE ONTICK EVENT
    public class TickEventManager : MonoBehaviour
    {
        public static TickEventManager Instance;
        
        public static event EventHandler<OnTickEventArgs> OnTick;

        // TODO: Explain how this works
        [SerializeField] private float TICK_TIMER_MAX = .2f; 
        private float TickTimer;
        
        private int Tick;

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this;
                Tick = 0;
            } 
        }
        
        private void Update()
        {
            TickTimer += Time.deltaTime;

            if (!(TickTimer >= TICK_TIMER_MAX)) return;
            TickTimer = 0;
            Tick++;
                
            OnTick?.Invoke(this, new OnTickEventArgs(Tick));
            Debug.Log(Tick);
        }
    }
    

}