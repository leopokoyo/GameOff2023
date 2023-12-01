using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextManager : MonoBehaviour
{
    WorldController[] planets;
    public TextMeshProUGUI standardTextBox;
    TextMeshProUGUI[][] textBoxes;

    public GameObject canvas;


    // Start is called before the first frame update

    void Start()
    {
        planets = FindObjectsOfType<WorldController>();

        textBoxes = new TextMeshProUGUI[planets.Length][];

        int j = 0;

        foreach (WorldController planet in planets)
        {
            int i = 0;

            textBoxes[j] = new TextMeshProUGUI[System.Enum.GetValues(typeof(Goods)).Length];

            List<Goods> keys = new List<Goods>(planet.planetData.inventory.Keys);
            foreach (Goods item in keys)
            {


                textBoxes[j][i] = Instantiate(standardTextBox, planet.transform.position, transform.rotation);
                textBoxes[j][i].text = item.ToString() + "\nStockpile: " + planet.planetData.inventory[item] + "\nPrice: " + planet.planetData.prices[item];
                textBoxes[j][i].transform.SetParent(canvas.transform, true);


                Vector3 startLocationText = Camera.main.WorldToScreenPoint(planet.transform.position);
                startLocationText.x += 150;
                startLocationText.y += System.Enum.GetValues(typeof(Goods)).Length * 37.5f - (i * 75 + 10);

                textBoxes[j][i].transform.position = startLocationText;

                textBoxes[j][i].enabled = false;


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
                    textBoxes[j][i].text = item.ToString() + " \nStockpile: " + planet.planetData.inventory[item] + " \nPrice: " + planet.planetData.prices[item];
                    i++;
                }
            }
            i = 0;
            j++;
        }
        j = 0;
    }


    public void ChooseDisplay(WorldController currentPlanet)
    {
        int j = 0;

        foreach (WorldController planet in planets)
        {
            for (int i = 0; i < System.Enum.GetValues(typeof(Goods)).Length; i++)
            {

                if (planet == currentPlanet)
                {
                    textBoxes[j][i].enabled = true;
                }
            }
            j++;
        }
        j = 0;
    }

    public void DeactivateDisplay()
    {
        int j = 0;

        foreach (WorldController planet in planets)
        {
            for (int i = 0; i < System.Enum.GetValues(typeof(Goods)).Length; i++)
            {
                textBoxes[j][i].enabled = false;
            }
            j++;
        }
        j = 0;
    }
}
