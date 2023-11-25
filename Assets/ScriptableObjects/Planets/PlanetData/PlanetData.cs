using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Planet/PlanetData")]
public class PlanetData : ScriptableObject
{
    public int population;
    public int basicProductConsumption;
    public int luxuryProductConsumtion;
    public float luxuryStandardPrice, basicStandardPrice;
    public int[] productionRate;
    public float taxRate;
    public Goods[] mainProduction;
<<<<<<< Updated upstream
    public Dictionary<Goods, int> inventory = new Dictionary<Goods, int>();
    public Dictionary<Goods, int> prices = new Dictionary<Goods, int>();
    public Vector3 planetLocation;

    void Awake(){
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
    }
=======
    public Dictionary<Goods, int> inventory = new Dictionary<Goods, int>()
    {
        {Goods.steelWool, 0},
        {Goods.goop, 0},
        {Goods.dogToys, 0},
        {Goods.cheese, 0},
        {Goods.water, 0}
    };
    public Dictionary<Goods, int> prices = new Dictionary<Goods, int>()
    {
        {Goods.steelWool, 3},
        {Goods.goop, 3},
        {Goods.dogToys, 3},
        {Goods.cheese, 3},
        {Goods.water, 10}
    };
    
    public Vector3 planetLocation;
>>>>>>> Stashed changes
}
