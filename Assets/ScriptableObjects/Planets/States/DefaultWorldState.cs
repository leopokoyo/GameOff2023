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

    public override void Update()
    {
        
            Consume();
            Produce();
            CalculatePrice();
    }

    void DailyUpdate()
    {

    }

    void Consume()
    {
        List<Goods> keys = new List<Goods>(Parent.inventory.Keys);
        foreach (Goods productAmount in keys){
            Debug.Log(productAmount);
            if (productAmount == Goods.water)
            {
                int luxConsumption = Parent.population / Parent.luxuryProductConsumtion;
                Parent.inventory[productAmount] -= luxConsumption;
            }

            else
            {
                int consumption = Parent.population / Parent.basicProductConsumption;
                Parent.inventory[productAmount] -= consumption;
            }
        }
    }

    void Produce()
    {
        for (int i = 0; i < Parent.mainProduction.Length; i++)
        {
            //calculate production based of population
            int production = Parent.population * Parent.productionRate[i];
            //change inventory based of production
            Parent.inventory[Parent.mainProduction[i]] += production;

        }
    }

    void Buy(/*ship,*/Goods item, int amountBought)
    {
        Parent.inventory[item] += amountBought;
        //player.inventory.Add(GiveMoney());
    }

    void Sell(/*ship,*/Goods item, int amountSold)
    {
        Parent.inventory[item] -= amountSold;
        //player.inventory.Add(-GetMoney());
    }

    void CalculatePrice()
    {
        int normalBasicStockpile = Parent.population / 2;
        int normalLuxuryStockpile = Parent.population / 3;
        float relativeStockpile;
        float fluidPrice;

        List<Goods> keys = new List<Goods>(Parent.inventory.Keys);
        foreach (Goods productAmount in keys)
        {
            if (productAmount == Goods.water)
            {
                relativeStockpile = Parent.inventory[productAmount] / normalLuxuryStockpile;
                float priceModifier = 1 + (1 - relativeStockpile);
                fluidPrice = Parent.luxuryStandardPrice * priceModifier;
                Parent.prices[productAmount] = (int)fluidPrice;
            }

            else
            {
                relativeStockpile = Parent.inventory[productAmount] / normalBasicStockpile;
                float priceModifier = 1 + (1 - relativeStockpile);
                fluidPrice = Parent.basicStandardPrice * priceModifier;
                Parent.prices[productAmount] = (int)fluidPrice;
            }
        }
    }

    int GetMoney(int amount, int price)
    {
        float fluidMoney = amount * price;
        fluidMoney *= 1 + Parent.taxRate;
        int money = (int)fluidMoney;
        return money;
    }

    int GiveMoney(int amount, int price)
    {
        float fluidMoney = amount * price;
        fluidMoney *= 1 - Parent.taxRate;
        int money = (int)fluidMoney;
        return money;
    }
}
