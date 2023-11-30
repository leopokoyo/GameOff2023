using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
public class BuyCommand : ICommand
{
    private int Quantity;
    private Goods GoodType;
    private ShipController Parent;
    private WorldController World;
    
    public BuyCommand(ShipController parent, WorldController world,Goods typeOfGood, int quantity)
    {
        Parent = parent;
        GoodType = typeOfGood;
        Quantity = quantity;
        World = world;
    }
    public void Execute()
    {
        if (PlayerInformation.instance.gold >= World.planetData.prices[GoodType] * Quantity)
        {
            PlayerInformation.instance.inventory[GoodType] += Quantity;
        }
        else
        {
            Debug.Log("NOT ENOUGH");
        }
    }
    public void Init()
    {
        throw new System.NotImplementedException();
    }
}