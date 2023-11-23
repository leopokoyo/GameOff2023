using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    WorldController[] planets;
    public TextMeshProUGUI standardTextBox;
    // Start is called before the first frame update

    void Start()
    {
        
        planets = GetComponentsInChildren<WorldController>();
        
        foreach (WorldController planet in planets)
        {
            List<Goods> keys = new List<Goods>(planet.planetData.inventory.Keys);
            Debug.Log(keys.Count);
            foreach (Goods item in keys)
            {
                {
                    TextMeshProUGUI textBox = Instantiate(standardTextBox, planet.planetData.planetLocation, transform.rotation);
                    textBox.text = item.ToString() + " Stockpile: " + planet.planetData.inventory[item] + " Price: " + planet.planetData.prices[item];
                }
            }
        }
    }
}
