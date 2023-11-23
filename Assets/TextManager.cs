using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    PlanetData[] planets;
    public TextMeshProUGUI standardTextBox;
    // Start is called before the first frame update

    void Start()
    {
        planets = GetComponentsInChildren<PlanetData>();

        foreach (PlanetData planet in planets)
        {
            List<Goods> keys = new List<Goods>(planet.inventory.Keys);
            foreach (Goods item in keys)
            {
                {
                    TextMeshProUGUI textBox = Instantiate(standardTextBox, planet.planetLocation, transform.rotation);
                    textBox.text = item.ToString() + " Stockpile: " + planet.inventory[item] + " Price: " + planet.prices[item];
                }
            }
        }
    }
}
