using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextManager : MonoBehaviour
{
    WorldController[] planets;
    public TextMeshProUGUI standardTextBox;
    
    //TextMeshProUGUI[,] textBoxes;
    TextMeshProUGUI[][] textBoxes;


    // Start is called before the first frame update

    void Start()
    {
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        planets = GetComponentsInChildren<WorldController>();
        

<<<<<<< Updated upstream

        var j = 0;
=======
        int j = 0;
>>>>>>> Stashed changes

        foreach (var planet in planets)
        {
            int i = 0;
            
            textBoxes[j] = new TextMeshProUGUI[System.Enum.GetValues(typeof(Goods)).Length]; 
            
            List<Goods> keys = new List<Goods>(planet.planetData.inventory.Keys);
            foreach (Goods item in keys)
            {
                

                Vector3 startLocationText = planet.planetData.planetLocation;
                startLocationText.x += 2;
                startLocationText.y = System.Enum.GetValues(typeof(Goods)).Length/2 - i; 

                textBoxes[j][i] = Instantiate(standardTextBox, startLocationText, transform.rotation);
                textBoxes[j][i].text = item.ToString() + "\nStockpile: " + planet.planetData.inventory[item] + "\nPrice: " + planet.planetData.prices[item];
                textBoxes[j][i].transform.SetParent(planet.transform, false);

                i++;
            }
            i = 0;
            
            j++;
        }
        j = 0;
    }

    private void OnEnable()
    {
        MainEventBus.NextDay += OnNewDay;
    }

   private void OnDisable()
    {
        MainEventBus.NextDay -= OnNewDay;
    }

    public void OnNewDay(object sender, int dayIndex)
    {
        
        int j = 0;

        foreach (WorldController planet in planets)
        {
            int i = 0;
            
            List<Goods> keys = new List<Goods>(planet.planetData.inventory.Keys);
            foreach (Goods item in keys)
            {
                {
                    Debug.Log(planet + " " + item.ToString() + " Stockpile: " + planet.planetData.inventory[item] + " Price: " + planet.planetData.prices[item]);
                    textBoxes[j][i].text = item.ToString() + " Stockpile: " + planet.planetData.inventory[item] + " Price: " + planet.planetData.prices[item];
                    i++;
                }
            }
            i = 0;
            j++;
        }
        j = 0;
    }
}
