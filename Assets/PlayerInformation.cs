using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static PlayerInformation instance { get; private set; }

    public Dictionary<Goods, int> inventory = new Dictionary<Goods, int>()
    {
        {Goods.steelWool, 0},
        {Goods.goop, 0},
        {Goods.dogToys, 0},
        {Goods.cheese, 0},
        {Goods.water, 0}
    };
    public int gold;
    
    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
