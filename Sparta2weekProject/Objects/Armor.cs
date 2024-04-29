

namespace Sparta2weekProject.Objects
{
    internal class Armor : Items
    {
        public Armor()
        {
            itemName = "누더기옷";
            type = ItemType.방어구;
            itemState = 1;
            description = "이 옷을 입을 바에는 벗는게 낫습니다.";
            price = 50;
        }
    }

    class PlateArmor : Armor
    {
        public PlateArmor()
        {
            itemName = "철갑옷";
            itemState = 5;
            description = "단단하고 묵직한 철갑옷입니다.";
            price = 400;
        }
    }
}
