using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ScriptableObjects;

[CreateAssetMenu(menuName = "State/WorldDefault")]
public class DefaultWorldState : State<WorldController>
{
    public override void ChangeState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    void DailyUpdate()
    {
        Consume();
        Produce();
        CalculatePrice();
    }

    void Consume()
    {
        //calculate consumption based of population size
        int steelWoolConsumption = Parent.population / Parent.basicProductConsumption;
        int goopConsumption = Parent.population / Parent.basicProductConsumption;
        int cheeseConsumption = Parent.population / Parent.basicProductConsumption;
        int waterConsumption = Parent.population / Parent.luxuryProductConsumtion;
        int dogToysConsumption = Parent.population / Parent.basicProductConsumption;

        //change inventory based of consumption
        Parent.inventory.Add("steelWool", -steelWoolConsumption);
        Parent.inventory.Add("goop", -goopConsumption);
        Parent.inventory.Add("cheese", -cheeseConsumption);
        Parent.inventory.Add("water", -waterConsumption);
        Parent.inventory.Add("dogToys", -dogToysConsumption);
    }

    void Produce()
    {
        //calculate production based of population
        int production = Parent.population * Parent.productionRate;

        //change inventory based of production
        Parent.inventory.Add(Parent.mainProduction, production);
    }

    void Buy(/*ship,*/string item, int amountBought)
    {
        Parent.inventory.Add(item, amountBought);
        //player.inventory.Add(GiveMoney());
    }

    void Sell(/*ship,*/string item, int amountSold)
    {
        Parent.inventory.Add(item, -amountSold);
        //player.inventory.Add(-GetMoney());
    }

    void CalculatePrice(){
        //for each price enum thing

        //find normal stockpile
        //Parent.population / 2 for basic goods;
        //Parent.population / 3 for luxury goods;

        //check currentstockpile compared to normal stockpile
        //relativeStockpile = currentStockpile/Stockpile;
        
        //calculate relative price because of stockpile or shortage
        //priceModifier = 1 + (1 - relativeStockpile);
        //productPrice = price * priceModifier;
    }

    int GetMoney(int amount, int price)
    {
        float fluidMoney = amount * price;
        fluidMoney *= (1 + Parent.taxRate);
        int money = (int)fluidMoney;
        return money;
    }

    int GiveMoney(int amount, int price)
    {
        float fluidMoney = amount * price;
        fluidMoney *= (1 - Parent.taxRate);
        int money = (int)fluidMoney;
        return money;
    }
}
