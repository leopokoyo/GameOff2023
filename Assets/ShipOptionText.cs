using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipOptionText : MonoBehaviour
{
    public ShipController ship;
    public WorldController[] planets = new WorldController[3];

    public TMP_Dropdown planetDropdown;
    public TMP_Dropdown goodDropdown;
    public TMP_Dropdown buySellDropdown;
    public TMP_InputField amountInput;
    
    Vector3 planetLocation = new Vector3(0,0,0);
    Goods typeOfGood;
    int amountOfGoods;

    bool isBuying;

    
    public void HandlePlanetInput(int val)
    {
        val = planetDropdown.value;
        if (val == 0){
            planetLocation = planets[1].transform.position;
        }

        if (val == 1){
            planetLocation = planets[2].transform.position;
        }

        if (val == 2){
            planetLocation = planets[3].transform.position;
        }
    }

    public void HandleTradeGoodInput(int val)
    {
        val = goodDropdown.value;
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

        if (val == 0){
            isBuying = true;
        }

        if (val == 1){
            isBuying = false;
        }
    }

    public void GiveInfo()
    {
        Debug.Log(planetLocation + " " + typeOfGood + " " + amountOfGoods + " " + isBuying);
    }
}
