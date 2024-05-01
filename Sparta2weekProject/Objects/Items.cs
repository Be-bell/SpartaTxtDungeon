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
            string state = item.Type == ItemType.무기 ? "공격력" : "방어력";
            string s = string.Format("{0, -10} | {1} +{2} | {3, -30}", item.ItemName, state, item.ItemState, item.Description);
            return s;
        }
      

    }

    public enum ItemType
    {
        무기, 방어구,포션
    }



    public class Portion : Items
    {
        public int PlusHp;
        public int PlusAtk;
        public int PlusDef;

        public virtual void Drink(Charactors charactor)
        {
            Console.WriteLine("포션을 사용했습니다");
        }
        public Portion(int hp, int atk,int Def)
        {
            PlusHp = hp;
            PlusAtk = atk;
            PlusDef = Def;
        }
    }


    public class PortionHP  :Portion
    {   
            public override void Drink(Charactors charactor)
        {
            base.Drink(charactor);
            charactor.Health += PlusHp;
            Console.WriteLine("채력 포션 한개를 마셨습니다 ");
            Console.WriteLine(  $"플레이어의 체력 : { charactor.FullHealth}");
        }
        public PortionHP(int hp, int atk, int Def) : base(hp, atk, Def) 
        {

        }
        }
    public class PortionAtk :Portion
    {
        public override void Drink(Charactors charactor)
        {
            base.Drink(charactor);   
            charactor.Attack += PlusAtk;
            Console.WriteLine("공격력 포션을 한개 마셨습니다 ");
            Console.WriteLine($"플레이어의 체력 : {charactor.Attack}");

        }
        public PortionAtk(int hp, int atk, int Def) : base(hp, atk, Def)
        {

        }
    }

    public class PortionDes : Portion
    {
        public override void Drink(Charactors charactor)
        {
            base.Drink(charactor);
            charactor.Defend += PlusDef;
            Console.WriteLine("방어력 포션을 한개 먹었습니다 ");
            Console.WriteLine($"플레이어의 방어력 :{ charactor.Defend}");
        }
        public PortionDes(int hp, int atk, int Def) : base(hp, atk, Def)
        {

        }
    }
}
