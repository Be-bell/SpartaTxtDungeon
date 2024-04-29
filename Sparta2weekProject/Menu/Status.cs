using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Status : MenuHandler
    {
        public Status()
        {
            menu = 0;
        }

        // 스탯창 메뉴
        public void StatusMenu(Charactors chad)
        {
            string plusAttackStr = chad.weapon != null ? $"(+ {chad.plusAttack})" : "";
            string plusDefendStr = chad.armor != null ? $"(+ {chad.plusDefend})" : "";
            
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0}", charactor.level.ToString("D2"));
            Console.WriteLine($"Chad ( {charactor.chad} )");
            Console.WriteLine($"공격력 : {charactor.attack + charactor.plusAttack}" + " " + plusAttackStr);
            Console.WriteLine($"방어력 : {charactor.defend + charactor.plusDefend}" + " " + plusDefendStr);
            Console.WriteLine($"체  력 : {charactor.health} / {charactor.fullHealth}");
            Console.WriteLine($"경험치 : {charactor.exp}");
            Console.WriteLine($" Gold  : {charactor.gold}\n");
            Console.WriteLine("0. 나가기\n");

            choice = base.Choice(menu, true);

        }

    }
}
