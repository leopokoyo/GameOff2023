using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] playerInfoText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;


        playerInfoText[i].text = "Gold" + " amount: " + PlayerInformation.instance.gold;


        List<Goods> keys = new List<Goods>(PlayerInformation.instance.inventory.Keys);
        foreach (Goods item in keys)
        {

                playerInfoText[i + 1].text = item + " amount: " + PlayerInformation.instance.inventory[item];
            
            i++;
        }
        i = 0;
    }
}
