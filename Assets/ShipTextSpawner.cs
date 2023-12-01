using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipTextSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    List<ShipController> ships = new List<ShipController>();
    public GameObject commandInfo;

    void Start()
    {   
        ships.Add(FindObjectOfType<ShipController>());
        ListUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ListUpdate()
    {
        ShipController[] currentShips = FindObjectsOfType<ShipController>();


        Debug.Log(currentShips.Length);
        for (int i = 0; i < currentShips.Length;)
        {
            if (i > ships.Count)
            {
                Debug.Log(i);
                ships.Add(currentShips[i]);
            }
        }

        foreach(ShipController ship in ships){
            GameObject shipText;
            
            shipText = Instantiate (commandInfo,transform.position, transform.rotation);
            shipText.transform.SetParent(this.transform, true);
        }
    }
}
