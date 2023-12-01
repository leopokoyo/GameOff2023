using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipOptionText : MonoBehaviour
{
    public ShipController ship;
    public WorldController[] planets = new WorldController[3];

    WorldController currentWorld;

    public TMP_Dropdown planetDropdown;
    public TMP_Dropdown goodDropdown;
    public TMP_Dropdown buySellDropdown;
    public TMP_InputField amountInput;

    List<ICommand> commands = new List<ICommand>();
    
    Vector3 planetLocation = new Vector3(0,0,0);
    Goods typeOfGood;
    int amountOfGoods;

    bool isBuying;

    
    public void HandlePlanetInput(int val)
    {
        val = planetDropdown.value;
        if (val == 1){
            planetLocation = planets[0].planetData.planetLocation;
            currentWorld = planets[0];
        }

        if (val == 2){
            planetLocation = planets[1].planetData.planetLocation;
            currentWorld = planets[1];
        }

        if (val == 3){
            planetLocation = planets[2].planetData.planetLocation;
            currentWorld = planets[2];
        }
    }

    public void HandleTradeGoodInput(int val)
    {
        val = goodDropdown.value;
        if (val == 1){
            typeOfGood = Goods.steelWool;
        }

        if (val == 2){
            typeOfGood = Goods.goop;
        }

        if (val == 3){
            typeOfGood = Goods.dogToys;
        }

        if (val == 4){
            typeOfGood = Goods.cheese;
        }

        if (val == 5){
            typeOfGood = Goods.water;
        }
    }

    public void HandleAmount(string val)
    {
        val = amountInput.text.ToString();
        amountOfGoods = int.Parse(val);
    }

    public void SetBuyOrSell(int val){
        val = buySellDropdown.value;

        if (val == 1){
            isBuying = true;
        }

        if (val == 2){
            isBuying = false;
        }
    }

    public void GiveInfo()
    {
        
        if (isBuying){
            commands.Add(new BuyCommand(ship, currentWorld, typeOfGood, amountOfGoods));
        }
        
        if (isBuying == false){
            commands.Add(new SellCommand(ship, currentWorld, typeOfGood, amountOfGoods));
        }

        TradeContract newContract = new TradeContract(planetLocation, commands);
        Debug.Log(commands.Count);

        ship.NewContract(newContract);

        commands.Remove(commands[0]);
    }
}
