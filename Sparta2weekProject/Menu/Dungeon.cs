using System.Drawing;
using System.Reflection.Emit;
using System.Numerics;
using Sparta2weekProject.Menu.BattleSystem;
using Sparta2weekProject.Objects.Charactor;



namespace Sparta2weekProject.Menu
{
    internal class Dungeon : MenuHandler
    {
        private Charactor charactor;
        private Random random;
        private int floor = 1; // 현재 던전 층

        public Dungeon()
        {
            menu = 3;
        }

        // 던전 입장 메뉴
        public void DungeonMenu(Charactor _charactor)
        {
            floor = 1; // 층 초기화
            charactor = _charactor;

            #region ConsolePrint
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("권장 방어력 이하로 던전을 수행할 시, 75% 확률로 실패할 수 있습니다.\n");
            Console.WriteLine($"1. 던전 : {DungeonLv.easy}  | 방어력 10 이상 권장");
            Console.WriteLine($"2. 던전 : {DungeonLv.normal}  | 방어력 25 이상 권장");
            Console.WriteLine($"3. 던전 : {DungeonLv.hard}  | 방어력 45 이상 권장\n");
            Console.WriteLine("0. 나가기\n");
            #endregion ConsolePrint

            // 선택 시 로직
            choice = base.Choice(menu, true);
            switch (choice)
            {
                case 1:
                    DungeonSelect(DungeonLv.easy);
                    //DungeonExplore(DungeonLv.easy, 10);
                    break;
                case 2:
                    DungeonSelect(DungeonLv.normal);
                    //DungeonExplore(DungeonLv.normal, 25);
                    break;
                case 3:
                    DungeonSelect(DungeonLv.hard);
                    //DungeonExplore(DungeonLv.hard, 45);
                    break;
            }
        }

        // 던전 진행 선택
        void DungeonSelect(DungeonLv level)
        {

            #region ConsolePrint
            Console.WriteLine($"{level}던전에 들어오셨습니다.\n");
            Console.WriteLine("0. 던전 나가기");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine($"2. 전투 시작 (현재 진행: {floor}층)");
            Console.WriteLine($"3. 포션사용하기 \n");
            #endregion ConsolePrint

            // 선택 시 로직
            choice = base.Choice(menu, true);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("던전을 나갑니다.\n");
                    break;
                case 1:
                    // 상태 보기
                    Status status = new Status();
                    status.StatusMenu(charactor);
                    DungeonSelect(level);
                    break;
                case 2:
                    DungeonExplore(level);
                    break;
                case 3:
                    Inventory inventory = new Inventory(charactor.Inven);
                    inventory.ItemPortion(charactor);
                    DungeonSelect(level);
                    break;


            }
        }

        // 던전 탐색
        void DungeonExplore(DungeonLv _lv)
        {
            int getReward = 0;
            int getExp = 0;
            int beforeHP = charactor.HP;
            //int minusHp = 0;
            random = new Random();

            // 난이도에 따른 보상
            switch (_lv)
            {
                case DungeonLv.easy:
                    //StartBattle(DungeonLv.easy);
                    getReward = 1000;
                    getExp = random.Next(11);
                    break;
                case DungeonLv.normal:
                    //StartBattle(DungeonLv.normal);
                    getReward = 1700;
                    getExp = random.Next(11, 21);
                    break;
                case DungeonLv.hard:
                    //StartBattle(DungeonLv.hard);
                    getReward = 2500;
                    getExp = random.Next(21, 31);
                    break;
            }

            // 전투 시작
            StartBattle(_lv);

            //minusHp = random.Next(20, 36) + (_recommandedDef - charactor.Defend);

            //if ((_recommandedDef > charactor.Defend && random.Next(1, 100) > 25) || _recommandedDef > charactor.HP)
            //{

            //    getReward = 0;
            //    minusHp = 50;
            //    if (minusHp > charactor.HP)
            //        minusHp = charactor.HP;
            //    getExp -= 10;
            //    if (getExp < 0)
            //        getExp = 0;
            //

            //공략 실패
            if (charactor.HP==0)
            {
                Console.WriteLine("던전 공략 실패");
                Console.WriteLine("던전 공략에 실패했습니다.\n");
                return;
            }

            //공략 성공
            #region Clear
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine($"던전 : {_lv} 을 클리어 했습니다.\n");


            floor++; // 클리어 후 층 증가

            #region Reward
            // 보상 수령 및 hp 감소
            int nextExp = charactor.Exp + getExp;
            int level = charactor.Level;
            if (nextExp >= 200)
            {
                Console.WriteLine("레벨업 하였습니다!\n");
                level++;
                charactor.Attack++;
                charactor.Defend += 2;
                nextExp -= 200;
            }
            
           // 보상 계산
            float rewardPercent = (random.Next(charactor.Attack, (charactor.Attack * 2) + 1) + 100) / 100.0f;
            int totalReward = (int) (getReward * rewardPercent);

            #region ConsolePrint
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {beforeHP} -> {charactor.HP}");
           
            Console.WriteLine($"Gold {charactor.Gold} -> {charactor.Gold + totalReward}");
            Console.WriteLine($"레벨 {charactor.Level} -> {level}");
            Console.WriteLine($"경험치 {charactor.Exp} -> {nextExp}");
            #endregion ConsolePrint

            //charactor.HP = charactor.HP - minusHp;
            charactor.Exp = nextExp;
            charactor.Level = level;
            charactor.Gold = charactor.Gold + totalReward;
            #endregion Reward
            // 캐릭터 사망
            //if (charactor.HP == 0)
            //{
            //    Console.WriteLine("\n캐릭터가 사망했습니다.");
            //    Console.WriteLine("게임 오버");
            //}

            Console.WriteLine("\n0. 로비로 나가기");
            Console.WriteLine("1. 던전 입구로\n");
            choice = base.Choice(1, true);
            if (choice == 0)
            {
                return;
            }

            if (floor == 6)
            {
                Console.WriteLine("꼭대기에 도착하여 던전에서 나갑니다.\n");
            }
            else
            {
                // 던전 로비로 이동
                DungeonSelect(_lv);
            }
            #endregion Clear

        }

        // 전투 시작
        void StartBattle(DungeonLv dungeonLevel)
        {
            
            // 몬스터 생성
            Monster[] monsters = CreateMonsters(dungeonLevel);

            if (monsters != null)
            {
                // 전투 시작
                Battle battle = new Battle(charactor, monsters);
                battle.InBattle();
            }

            //몬스터 생성이 되지 않았을 때.
            else
            {
                Console.WriteLine("몬스터를 생성하는 데 문제가 발생했습니다.");
            }
        }

        // 던전 레벨에 따라 몬스터 생성
        Monster[] CreateMonsters(DungeonLv dungeonLevel)
        {
            int monsterCount; // 몬스터 개체 수
            int monsterAttack = 0; // 층에 따른 몬스터 추가 공격력
            int monsterHp = 0; // 층에 따른 몬스터 추가 체력
            Monster[] MonstersLevel; // 난이도에 따른 몬스터 정보
            switch (dungeonLevel)
            {
                case DungeonLv.easy:
                    monsterCount = random.Next(1, 3);
                    MonstersLevel = new Monster[]
                    {
                          new Monster("미니언", 15, 50, 3),
                          new Monster("대포미니언", 25, 60,4),
                          new Monster("공허충", 10, 65, 6)
                    };
                    break;
                case DungeonLv.normal:
                    monsterCount = random.Next(1, 4);
                    monsterAttack = random.Next(0, 3);
                    monsterHp = random.Next(0, 5);
                    MonstersLevel = new Monster[]
                    {
                        new Monster("미니언", 15, 40 + monsterHp, 5 + monsterAttack),
                        new Monster("대포미니언", 25, 50 + monsterHp,6 + monsterAttack),
                        new Monster("공허충", 10, 70 + monsterHp, 8 + monsterAttack)
                    };
                    break;
                case DungeonLv.hard:
                    monsterCount = random.Next(2, 4);
                    monsterAttack = random.Next(3, 7);
                    monsterHp = random.Next(5, 15);
                    MonstersLevel = new Monster[]
                    {
                        new Monster("미니언", 15, 50 + monsterHp, 8 + monsterAttack),
                        new Monster("대포미니언", 25, 70 + monsterHp, 9 + monsterAttack),
                        new Monster("공허충", 10, 150 + monsterHp, 10 + monsterAttack)
                    };
                    break;
                default:
                    throw new ArgumentException("올바르지 않은 던전 레벨입니다.");
            }

            // 해당 몬스터 정보를 토대로 monsterCount만큼 랜덤으로 스폰
            Monster[] randomMonster = new Monster[monsterCount];
            for(int i = 0; i < monsterCount; i++)
            {
                // Monster[]에서 옮기면 얕은 복사가 되므로 새로운 객체를 만들어 생성함 (Monster.cs 33줄)
                Monster monsterClone = new Monster(MonstersLevel[random.Next(0, 3)]);
                randomMonster[i] = monsterClone;
            }
            return randomMonster;
        }
    }
    enum DungeonLv
    {
        easy = 1, normal, hard
    }
}
