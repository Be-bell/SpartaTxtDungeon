using Sparta2weekProject.Interfaces;

namespace Sparta2weekProject.Objects
{
    // Item들의 부모클래스, Item들끼리 겹치는 부분들을 미리 합쳐놓음.
    public class Items : IItems
    {
        public bool isEquiped { get; set; }
        public bool isPurchase { get; set; }
        public string itemName { get; set; }
        public int itemState { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public ItemType type { get; set; }

        public string ItemInfo(Items item)
        {
            string state = item.type == ItemType.무기 ? "공격력" : "방어력";
            string s = string.Format("{0, -10} | {1} +{2} | {3, -30}", item.itemName, state, item.itemState, item.description);
            return s;
        }

    }

    public enum ItemType
    {
        무기, 방어구
    }

}
