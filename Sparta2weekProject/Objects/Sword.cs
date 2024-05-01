

namespace Sparta2weekProject.Objects
{
    internal class Sword : Items
    {
        public Sword()
        {
            ItemName = "쫄따구검";
            Type = ItemType.Weapon;
            ItemState = 1;
            Description = "쫄따구들만 쓰는 검입니다.";
            Price = 50;
        }
    }

    class SuperSword : Sword
    {
        public SuperSword()
        {
            ItemName = "짱쌘검";
            ItemState = 5;
            Description = "짱쌥니다.";
            Price = 500;
        }
    }

    class UltraSword : Sword
    {
        public UltraSword()
        {
            ItemName = "지존짱쌘검";
            ItemState = 8;
            Description = "지존짱쌥니다.";
            Price = 900;
        }
    }
}
