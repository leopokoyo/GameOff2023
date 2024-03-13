using _2._Scripts.Items.Enums;
using UnityEngine;

namespace _2._Scripts.Items
{
    public class GameItem : MonoBehaviour
    {
        
        // Auto generated Values
        private int productionTime;
        private int max;
        private string description;

        private ItemType type;

        public GameItem(ItemType type)
        {
            this.type = type;

            AnalyseType();
        }
        
        // TODO: Parse JSON file and find the information for the item when generated
        private void AnalyseType()
        {
            productionTime = 0;
            max = 0;
            description = "";
        }
    }
}