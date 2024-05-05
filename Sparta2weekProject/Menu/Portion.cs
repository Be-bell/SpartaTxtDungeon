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

    public class Portion : Items
    {

        public int PlusHp;
        public int PlusAtk;
        public int PlusDef;

        public virtual void Drink(Charactor charactor,int input)
        {
            Console.WriteLine("포션을 사용했습니다");
        }
        public Portion(int hp, int atk, int Def, string name)
        {
            PlusHp = hp;
            PlusAtk = atk;
            PlusDef = Def;
            ItemName = name;
        }



    }


    public class PortionHP : Portion
    {
        public override void Drink(Charactor charactor, int input)
        {
            base.Drink(charactor, input);
            if (charactor.HP < charactor.FullHP)
            {
                //hp98일때  +10 해도 fullhp값이 넘어가지않게 

                charactor.HP += PlusHp;
                if (charactor.HP > charactor.FullHP) // 넘쳤을때 예외처리
                {
                    charactor.HP = charactor.FullHP; // 최대체력과  체력량을 똑같게만든다
                }

                Console.WriteLine("채력 포션 한개를 마셨습니다 ");
                Console.WriteLine($"플레이어의 체력 : {charactor.HP}");
                  charactor.PortionHP.RemoveAt(0);
            }

            else
            {
                Console.WriteLine("체력이 가득찼습니다 물약을먹지 못합니다");
                Console.WriteLine($"플레이어의 체력 : {charactor.HP}");
            }
        }

        public PortionHP(int hp, int atk, int Def, string name) : base(hp, atk, Def, name)
        {

        }
    }
    public class PortionAtk : Portion
    {
        public override void Drink(Charactor charactor, int input)
        {
            base.Drink(charactor, input);
            charactor.Attack += PlusAtk;
            charactor.PortionAtk.RemoveAt(0);
            Console.WriteLine("공격력 포션을 한개 마셨습니다 ");
            Console.WriteLine($"플레이어의 공격력 : {charactor.Attack}");

        }
        public PortionAtk(int hp, int atk, int Def, string name) : base(hp, atk, Def, name)
        {

        }
    }

    public class PortionDes : Portion
    {
        public override void Drink(Charactor charactor, int input)
        {
            base.Drink(charactor, input);
            charactor.Defend += PlusDef;
            charactor.PortionDef.RemoveAt(0);
            Console.WriteLine("방어력 포션을 한개 먹었습니다 ");
            Console.WriteLine($"플레이어의 방어력 :{charactor.Defend}");
        }
        public PortionDes(int hp, int atk, int Def, string name) : base(hp, atk, Def, name)
        {

        }
    }
}
