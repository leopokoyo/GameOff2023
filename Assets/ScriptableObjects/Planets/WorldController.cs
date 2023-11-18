using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class WorldController : StateRunner<WorldController>
{
    public int population;

    public int basicProductConsumption;
    public int luxuryProductConsumtion;
    public int productionRate;

    public float taxRate;

    public string mainProduction;

    public enum Product
    {
        //cat planet good
        steelWool,
        //goop planet good
        goop,
        //Earth planet good
        cheese,
        water,
        //dog planet good
        dogToys,
    }

    public enum Price
    {
        //cat planet good
        steelWoolPrice,
        //goop planet good
        goopPrice,
        //Earth planet good
        cheesePrice,
        waterPrice,
        //dog planet good
        dogToysPrice,

    }

    public Dictionary<string, int> inventory = new Dictionary<string, int>();
}
