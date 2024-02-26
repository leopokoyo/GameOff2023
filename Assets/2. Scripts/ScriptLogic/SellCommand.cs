using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCommand : ICommand
{
    private int Quantity;
    private Goods GoodType;
    private ShipController Parent;
    private WorldController World;


    public SellCommand(ShipController parent, WorldController world, Goods typeOfGood, int quantity)
    {
        Parent = parent;
        GoodType = typeOfGood;
        Quantity = quantity;
        World = world;
    }

    public void Execute()
    {
        if (World.planetData.prices[GoodType] >= Quantity)
        {
            PlayerInformation.instance.inventory[GoodType] -= Quantity;
            World.Sell(GoodType, Quantity);
            PlayerInformation.instance.gold += World.GetMoney(Quantity, GoodType);
        }
    }

    public void Init()
    {
        
    }

}
