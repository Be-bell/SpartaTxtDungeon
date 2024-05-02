using Sparta2weekProject.Objects;
using Sparta2weekProject.Objects.Charactor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta2weekProject.Menu
{
    public enum PortionType
    {
        HpPosion ,공격력포션,방어력포션
    }
    public class Portion : Items
    {
        
        public int PlusHp;
        public int PlusAtk;
        public int PlusDef;

        public virtual void Drink(Charactor charactor)
        {
            Console.WriteLine("포션을 사용했습니다");
        }
        public Portion(int hp, int atk, int Def)
        {
            PlusHp = hp;
            PlusAtk = atk;
            PlusDef = Def;
        }

        //public Portion(PortionType portionType)
        //{
        //    PortionType name = portionType;
        //}

    }


    public class PortionHP : Portion
    {
        public override void Drink(Charactor charactor)
        {
            base.Drink(charactor);
            charactor.HP += PlusHp;
            Console.WriteLine("채력 포션 한개를 마셨습니다 ");
            Console.WriteLine($"플레이어의 체력 : {charactor.HP}");
        }
        public PortionHP(int hp, int atk, int Def) : base(hp, atk, Def)
        {

        }
    }
    public class PortionAtk : Portion
    {
        public override void Drink(Charactor charactor)
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
        public override void Drink(Charactor charactor)
        {
            base.Drink(charactor);
            charactor.Defend += PlusDef;
            Console.WriteLine("방어력 포션을 한개 먹었습니다 ");
            Console.WriteLine($"플레이어의 방어력 :{charactor.Defend}");
        }
        public PortionDes(int hp, int atk, int Def) : base(hp, atk, Def)
        {

        }
    }
}
