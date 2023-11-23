using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ScriptableObjects;

public class ProductBarManager : MonoBehaviour
{
    [SerializeField] WorldController planet;

    public Goods product;

    public TextMeshProUGUI price;
    public TextMeshProUGUI stock;
    public TextMeshProUGUI productText;

    void Start(){
        productText.text = product.ToString();
    }
    void Update()
    {
        foreach (KeyValuePair<Goods, int> productAmount in planet.planetData.inventory)
        {
            if (productAmount.Key == product)
            {
                price.text = "Price: " + planet.planetData.prices[productAmount.Key];
                stock.text = "Stockpile: " + planet.planetData.inventory[productAmount.Key];
            }
        }
    }

}
