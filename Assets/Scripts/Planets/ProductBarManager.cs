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
        foreach (KeyValuePair<Goods, int> productAmount in planet.inventory)
        {
            if (productAmount.Key == product)
            {
                price.text = "Price: " + planet.prices[productAmount.Key];
                stock.text = "Stockpile: " + planet.inventory[productAmount.Key];
            }
        }
    }

}
