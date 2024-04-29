

namespace Sparta2weekProject.Objects
{
    internal class Armor : Items
    {
        public Armor()
        {
            ItemName = "누더기옷";
            Type = ItemType.방어구;
            ItemState = 1;
            Description = "이 옷을 입을 바에는 벗는게 낫습니다.";
            Price = 50;
        }
    }

    class PlateArmor : Armor
    {
        public PlateArmor()
        {
            ItemName = "철갑옷";
            ItemState = 5;
            Description = "단단하고 묵직한 철갑옷입니다.";
            Price = 400;
        }
    }
}
