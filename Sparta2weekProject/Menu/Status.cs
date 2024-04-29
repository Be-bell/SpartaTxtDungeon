using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Status : MenuHandler
    {
        Charactors charactor;
        public Status()
        {
            menu = 0;
        }

        // 스탯창 메뉴
        public void StatusMenu(Charactors chad)
        {
            charactor = _charactor;
            string plusAttackStr = charactor.Weapon != null ? $"(+ {charactor.PlusAttack})" : "";
            string plusDefendStr = charactor.Armor != null ? $"(+ {charactor.PlusDefend})" : "";
            
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0}", charactor.Level.ToString("D2"));
            Console.WriteLine($"Chad ( {charactor.Class} )");
            Console.WriteLine($"공격력 : {charactor.Attack + charactor.PlusAttack}" + " " + plusAttackStr);
            Console.WriteLine($"방어력 : {charactor.Defend + charactor.PlusDefend}" + " " + plusDefendStr);
            Console.WriteLine($"체  력 : {charactor.Health} / {charactor.FullHealth}");
            Console.WriteLine($"경험치 : {charactor.Exp}");
            Console.WriteLine($" Gold  : {charactor.Gold}\n");
            Console.WriteLine("0. 나가기\n");

            choice = base.Choice(menu, true);

        }

    }
}
