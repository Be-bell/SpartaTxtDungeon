using Sparta2weekProject.Interfaces;
using System.Globalization;

namespace Sparta2weekProject.Objects
{
    // Item들의 부모클래스, Item들끼리 겹치는 부분들을 미리 합쳐놓음.
    public class Items : IItems
    {
        public bool IsEquiped;
        public bool IsPurchase;
        public string ItemName;
        public int ItemState;
        public string Description;
        public int Price;
   
        public ItemType Type;

        public string ItemInfo(Items item)
        {
            string state = item.Type == ItemType.Weapon ? "공격력" : "방어력";
            string s = string.Format("{0, -10} | {1} +{2} | {3, -30}", item.ItemName, state, item.ItemState, item.Description);
            return s;
        }
      

    }

    public enum ItemType
    {
        Weapon, Armor
    }



  
}

