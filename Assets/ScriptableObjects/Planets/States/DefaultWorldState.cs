using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ScriptableObjects;
using UnityEngine.Animations;

[CreateAssetMenu(menuName = "State/WorldDefault")]
public class DefaultWorldState : State<WorldController>
{
    bool dailyTick = true;
    


    public override void ChangeState()
    {

    }

    public override void ExitState()
    {

    }

    public override void HandleInput()
    {

    }

    public override void Update(){}

    public override void NewDay()
    {
        //_activeState.NewDay();

        Consume();
        Produce();
        CalculatePrice();
    }

    void Consume()
    {
        List<Goods> keys = new List<Goods>(Parent.planetData.inventory.Keys);
        foreach (Goods productAmount in keys){
            if (productAmount == Goods.water)
            {
                int luxConsumption = Parent.planetData.population / Parent.planetData.luxuryProductConsumtion;
                Parent.planetData.inventory[productAmount] -= luxConsumption;
            }

            else
            {
                int consumption = Parent.planetData.population / Parent.planetData.basicProductConsumption;
                Parent.planetData.inventory[productAmount] -= consumption;
            }
        }
    }

    void Produce()
    {
        for (int i = 0; i < Parent.planetData.mainProduction.Length; i++)
        {
            //calculate production based of population
            int production = Parent.planetData.population * Parent.planetData.productionRate[i];
            //change inventory based of production
            Parent.planetData.inventory[Parent.planetData.mainProduction[i]] += production;
        }
    }

    

    void CalculatePrice()
    {
        int normalBasicStockpile = Parent.planetData.population / 2;
        int normalLuxuryStockpile = Parent.planetData.population / 3;
        float relativeStockpile;
        float fluidPrice;

        List<Goods> keys = new List<Goods>(Parent.planetData.inventory.Keys);
        foreach (Goods productAmount in keys)
        {
            if (productAmount == Goods.water)
            {
                relativeStockpile = Parent.planetData.inventory[productAmount] / normalLuxuryStockpile;
                float priceModifier = 1 + (1 - relativeStockpile);
                fluidPrice = Parent.planetData.luxuryStandardPrice * priceModifier;
                Parent.planetData.prices[productAmount] = (int)fluidPrice;
            }

            else
            {
                relativeStockpile = Parent.planetData.inventory[productAmount] / normalBasicStockpile;
                float priceModifier = 1 + (1 - relativeStockpile);
                fluidPrice = Parent.planetData.basicStandardPrice * priceModifier;
                Parent.planetData.prices[productAmount] = (int)fluidPrice;
            }
        }
    }

}
