using System;
using UnityEngine;

namespace _2._Scripts.Items.Managers
{
    public class ItemManager : MonoBehaviour
    {
        public static ItemManager Instance { get; private set; }
        
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
    }
}