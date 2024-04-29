

namespace Sparta2weekProject.Objects
{
    internal class Sword : Items
    {
        public Sword()
        {
            itemName = "쫄따구검";
            type = ItemType.무기;
            itemState = 1;
            description = "쫄따구들만 쓰는 검입니다.";
            price = 50;
        }
    }

    class SuperSword : Sword
    {
        public SuperSword()
        {
            itemName = "짱쌘검";
            itemState = 5;
            description = "짱쌥니다.";
            price = 500;
        }
    }

    class UltraSword : Sword
    {
        public UltraSword()
        {
            itemName = "지존짱쌘검";
            itemState = 8;
            description = "지존짱쌥니다.";
            price = 900;
        }
    }
}
