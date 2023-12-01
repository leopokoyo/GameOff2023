using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class WorldController : StateRunner<WorldController>
{
    
    public PlanetData planetData;

    private TextManager canvas;

    void Start(){

        SetState(typeof(DefaultWorldState));

        canvas = FindObjectOfType<TextManager>();

        planetData.planetLocation = transform.position;

        //infoScreen.SetActive(false);
    }

    void OnMouseOver(){
        canvas.ChooseDisplay(this);
    }

    void OnMouseExit(){
        canvas.DeactivateDisplay();
    }

    private void OnEnable()
    {
        MainEventBus.NextDay += OnNewDay;
    }

   private void OnDisable()
    {
        MainEventBus.NextDay -= OnNewDay;
    }

  private void OnNewDay(object sender, int dayIndex)
    {
        _activeState.NewDay();
    }

    public void Buy(Goods item, int amountBought)
    {
        planetData.inventory[item] += amountBought;
        //player.inventory.Add(GiveMoney());
    }

    public void Sell(Goods item, int amountSold)
    {
        planetData.inventory[item] -= amountSold;
        //player.inventory.Add(-GetMoney());
    }

    public int GetMoney(int amount, Goods typeOfGood)
    {
        float fluidMoney = amount * planetData.prices[typeOfGood];
        fluidMoney *= 1 + planetData.taxRate;
        int money = (int)fluidMoney;
        return money;
    }

    public int GiveMoney(int amount, Goods typeOfGood)
    {
        float fluidMoney = amount * planetData.prices[typeOfGood];
        fluidMoney *= 1 - planetData.taxRate;
        int money = (int)fluidMoney;
        return money;
    }
}
