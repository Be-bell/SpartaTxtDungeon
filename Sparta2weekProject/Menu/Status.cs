using Sparta2weekProject.Objects;
using Sparta2weekProject.Objects.Charactor;

namespace Sparta2weekProject.Menu
{
    internal class Status : MenuHandler
    {
        Charactor charactor;
        public Status()
        {
            menu = 0;
        }

        // 스탯창 메뉴
        public void StatusMenu(Charactor _charactor)
        {
            charactor = _charactor;
            Items? weapon = charactor.Weapon;
            Items? armor = charactor.Armor;

            string plusAttackStr = "";
            string plusDefendStr = "";
            string weaponName = "없음";
            string armorName = "없음";
            if (weapon != null)
            {
                plusAttackStr = String.Format($"(+ {charactor.PlusAttack})");
                weaponName = String.Format($"{weapon.ItemName}");
            }

            if(armor != null)
            {
                plusDefendStr = String.Format($"(+ {charactor.PlusDefend})");
                armorName = String.Format($"{armor.ItemName}");
            }
            
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("==========================================");
            Console.WriteLine($"이  름 : {charactor.Name}");
            Console.WriteLine("Lv. {0}", charactor.Level.ToString("D2"));
            Console.WriteLine($"Chad ( {charactor.Class} )");
            Console.WriteLine($"공격력 : {charactor.Attack + charactor.PlusAttack}" + " " + plusAttackStr);
            Console.WriteLine($"방어력 : {charactor.Defend + charactor.PlusDefend}" + " " + plusDefendStr);
            Console.WriteLine($"체  력 : {charactor.HP} / {charactor.FullHP}");
            Console.WriteLine($"경험치 : {charactor.Exp}");
            Console.WriteLine($" Gold  : {charactor.Gold}");
            Console.WriteLine("==========================================");
            Console.WriteLine($"현재 장착한 무기 : [{weaponName}]");
            Console.WriteLine($"현재 장착한 방어구 : [{armorName}]");
            Console.WriteLine($"HP포션 :{charactor.PortionHP.Count}");
            Console.WriteLine($"공격력포션 :{charactor.PortionAtk.Count}");
            Console.WriteLine($"방어력포션 :{charactor.PortionDef.Count}");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n0. 나가기\n");

            choice = base.Choice(menu, true);

        }
    }
}
