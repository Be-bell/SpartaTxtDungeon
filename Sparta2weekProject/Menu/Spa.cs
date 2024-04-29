using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Spa : MenuHandler
    {
        Charactors chad;

        public Spa()
        {
            menu = 1;
        }

        public void SpaMenu(Charactors _chad)
        {
            chad = _chad;
            Console.WriteLine("온천 : 휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {chad.gold} G)\n");

            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기\n");

            choice = base.Choice(menu, true);
            if (choice == 0) return;

            if (chad.gold < 500)
            {
                Console.WriteLine("\n돈이 부족합니다.\n");
            }
            else
            {
                Console.WriteLine("휴식하였습니다. (-500 G)\n");
                chad.gold -= 500;
                chad.health += 100;
                if (chad.health > chad.fullHealth)
                    chad.health = chad.fullHealth;
            }
        }
    }
}
