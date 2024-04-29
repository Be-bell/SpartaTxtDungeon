using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Dungeon : MenuHandler
    {
        Charactors charactor;
        Random random;

        public Dungeon() 
        {
            menu = 3;
        }

        // 던전 입장 메뉴
        public void DungeonMenu(Charactors _charactor)
        {
           charactor = _charactor;

            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("권장 방어력 이하로 던전을 수행할 시, 75% 확률로 실패할 수 있습니다.\n");
            Console.WriteLine($"1. 던전 : {DungeonLv.쉬움}  | 방어력 10 이상 권장");
            Console.WriteLine($"2. 던전 : {DungeonLv.일반}  | 방어력 25 이상 권장");
            Console.WriteLine($"3. 던전 : {DungeonLv.어려움}  | 방어력 45 이상 권장\n");
            Console.WriteLine("0. 나가기\n");

            // 선택 시 로직
            choice = base.Choice(menu, true);
            switch(choice)
            {
                case 1:
                    DungeonExplore(DungeonLv.쉬움, 10);
                    break;
                case 2:
                    DungeonExplore(DungeonLv.일반, 25);
                    break;
                case 3:
                    DungeonExplore(DungeonLv.어려움, 45);
                    break;
            }
        }

        // 던전 탐색
        void DungeonExplore(DungeonLv _lv, int _recommandedDef)
        {
            int getReward=0;
            int getExp = 0;
            int minusHp = 0;
            random = new Random();

            // 난이도에 따른 보상
            switch (_lv)
            {
                case DungeonLv.쉬움:
                    getReward = 1000;
                    getExp = random.Next(11);
                    break;
                case DungeonLv.일반:
                    getReward = 1700;
                    getExp = random.Next(11, 21);
                    break;
                case DungeonLv.어려움:
                    getReward = 2500;
                    getExp = random.Next(21, 31);
                    break;
            }

            minusHp = random.Next(20, 36) + (_recommandedDef - charactor.defend);

            if ((_recommandedDef > charactor.defend && random.Next(1,100) > 25) || _recommandedDef > charactor.health)
            {
                //공략 실패
                Console.WriteLine("던전 공략 실패");
                Console.WriteLine("던전 공략에 실패했습니다.\n");
                getReward = 0;
                minusHp = 50;
                if(minusHp > charactor.health)
                    minusHp = charactor.health;
                getExp -= 10;
                if(getExp < 0) 
                    getExp = 0;
            }
            else
            {
                //공략 성공
                Console.WriteLine("던전 클리어");
                Console.WriteLine("축하합니다!!");
                Console.WriteLine($"던전 : {_lv} 을 클리어 했습니다.\n");
            }

            // 보상 수령 및 hp 감소
            int nextExp = charactor.exp + getExp;
            int level = charactor.level;
            if(nextExp >= 200)
            {
                Console.WriteLine("레벨업 하였습니다!\n");
                level++;
                charactor.attack++;
                charactor.defend += 2;
                nextExp -= 200;
            }
            float rewardPercent = (random.Next(charactor.attack, (charactor.attack*2) + 1) + 100) / 100.0f;
            int totalReward = (int) (getReward * rewardPercent);
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {charactor.health} -> {charactor.health - minusHp}");
            Console.WriteLine($"Gold {charactor.gold} -> {charactor.gold + totalReward}");
            Console.WriteLine($"레벨 {charactor.level} -> {level}");
            Console.WriteLine($"경험치 {charactor.exp} -> {nextExp}");
            charactor.health = charactor.health - minusHp;
            charactor.gold = charactor.gold + totalReward;

            // 캐릭터 사망
            if(charactor.health == 0)
            {
                Console.WriteLine("\n캐릭터가 사망했습니다.");
                Console.WriteLine("게임 오버");
            }

            Console.WriteLine("\n0. 나가기\n");

            choice = base.Choice(0, true);
        }
    }
    enum DungeonLv
    {
        쉬움=1, 일반, 어려움
    }
}
