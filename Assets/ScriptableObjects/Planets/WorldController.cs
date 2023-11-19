using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class WorldController : StateRunner<WorldController>
{
    public int population;

    public int basicProductConsumption;
    public int luxuryProductConsumtion;
    public float luxuryStandardPrice, basicStandardPrice;
    public int[] productionRate;

    [SerializeField] GameObject infoScreen;

    public float taxRate;

    public Goods[] mainProduction;

    public Dictionary<Goods, int> inventory = new Dictionary<Goods, int>();
    public Dictionary<Goods, int> prices = new Dictionary<Goods, int>();

    void Start(){
        inventory.Add(Goods.steelWool, 0);
        inventory.Add(Goods.goop, 0);
        inventory.Add(Goods.dogToys, 0);
        inventory.Add(Goods.cheese, 0);
        inventory.Add(Goods.water, 0);

        prices.Add(Goods.steelWool, 3);
        prices.Add(Goods.goop, 3);
        prices.Add(Goods.dogToys, 3);
        prices.Add(Goods.cheese, 3);
        prices.Add(Goods.water, 10);

        SetState(typeof(DefaultWorldState));

        infoScreen.SetActive(false);
    }


    void OnMouseOver(){
        infoScreen.SetActive(true);
    }

    void OnMouseExit(){
        infoScreen.SetActive(false);
    }
}
