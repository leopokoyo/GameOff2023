using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using TMPro;
=======
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
>>>>>>> BartsThirdBranch
using UnityEngine;
using UnityEngine.UI;

public class ShipOptionText : MonoBehaviour
{
    public ShipController ship;
    public WorldController[] planets = new WorldController[3];

<<<<<<< HEAD
=======
    WorldController currentWorld;

>>>>>>> BartsThirdBranch
    public TMP_Dropdown planetDropdown;
    public TMP_Dropdown goodDropdown;
    public TMP_Dropdown buySellDropdown;
    public TMP_InputField amountInput;
<<<<<<< HEAD
=======

    List<ICommand> commands = new List<ICommand>();
>>>>>>> BartsThirdBranch
    
    Vector3 planetLocation = new Vector3(0,0,0);
    Goods typeOfGood;
    int amountOfGoods;

    bool isBuying;

    
    public void HandlePlanetInput(int val)
    {
        val = planetDropdown.value;
<<<<<<< HEAD
        if (val == 0){
            planetLocation = planets[1].transform.position;
        }

        if (val == 1){
            planetLocation = planets[2].transform.position;
        }

        if (val == 2){
            planetLocation = planets[3].transform.position;
=======
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
>>>>>>> BartsThirdBranch
        }
    }

    public void HandleTradeGoodInput(int val)
    {
        val = goodDropdown.value;
<<<<<<< HEAD
        if (val == 0){
            typeOfGood = Goods.steelWool;
        }

        if (val == 1){
            typeOfGood = Goods.goop;
        }

        if (val == 2){
            typeOfGood = Goods.dogToys;
        }

        if (val == 3){
            typeOfGood = Goods.cheese;
        }

        if (val == 4){
=======
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
>>>>>>> BartsThirdBranch
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

<<<<<<< HEAD
        if (val == 0){
            isBuying = true;
        }

        if (val == 1){
=======
        if (val == 1){
            isBuying = true;
        }

        if (val == 2){
>>>>>>> BartsThirdBranch
            isBuying = false;
        }
    }

    public void GiveInfo()
    {
<<<<<<< HEAD
        Debug.Log(planetLocation + " " + typeOfGood + " " + amountOfGoods + " " + isBuying);
=======
        
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
>>>>>>> BartsThirdBranch
    }
}
