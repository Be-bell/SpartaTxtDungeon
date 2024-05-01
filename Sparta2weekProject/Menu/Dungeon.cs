using System.Drawing;
using System.Reflection.Emit;
﻿using Sparta2weekProject.BattleSystem;
using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Dungeon : MenuHandler
    {
        Charactors charactor;
        Random random;
        int floor = 1; // 현재 던전 층

        public Dungeon() 
        {
            menu = 3;
        }

        // 던전 입장 메뉴
        public void DungeonMenu(Charactors _charactor)
        {
            floor = 1; // 층 초기화
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
                    DungeonSelect(DungeonLv.쉬움, 10);
                    //DungeonExplore(DungeonLv.쉬움, 10);
                    break;
                case 2:
                    DungeonSelect(DungeonLv.일반, 25);
                    //DungeonExplore(DungeonLv.일반, 25);
                    break;
                case 3:
                    DungeonSelect(DungeonLv.어려움, 45);
                    //DungeonExplore(DungeonLv.어려움, 45);
                    break;
            }
        }

        // 던전 진행 선택
        void DungeonSelect(DungeonLv level, int def)
        {
            Console.WriteLine($"{level}던전에 들어오셨습니다.\n");
            Console.WriteLine("0. 던전 나가기");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine($"2. 전투 시작 (현재 진행: {floor}층)\n");

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
                    DungeonSelect(level, def);
                    break;
                case 2:
                    // 던전 입장
                    //DungeonInvite(floor, level);
                    DungeonExplore(level, def);
                    break;
            }
        }

        // 던전 입장
        void DungeonInvite(int floor, DungeonLv level)
        {
            // 몬스터 개수
            int monsterCount;
            // 강한 몬스터
            int monsterAttack;
            // int monsterDeffend = random.Next();

            // 난이도에 따른 보상
            switch (level)
            {
                case DungeonLv.쉬움:
                    monsterCount = random.Next(1, 2);
                    break;
                case DungeonLv.일반:
                    monsterCount = random.Next(1, 4);
                    monsterAttack = random.Next(0, 3);
                    break;
                case DungeonLv.어려움:
                    monsterCount = random.Next(2, 4);
                    monsterAttack = random.Next(3, 7);
                    break;
            }

            // 몬스터 소환 및 값 공격력 변경
            // 전투 시작

            // 보상 획득


            // 전투 끝으로 층 상승
            floor++;
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
                    StartBattle(DungeonLv.쉬움);
                    getReward = 1000;
                    getExp = random.Next(11);
                    break;
                case DungeonLv.일반:
                    StartBattle(DungeonLv.일반);
                    getReward = 1700;
                    getExp = random.Next(11, 21);
                    break;
                case DungeonLv.어려움:
                    StartBattle(DungeonLv.어려움);
                    getReward = 2500;
                    getExp = random.Next(21, 31);
                    break;
            }

            minusHp = random.Next(20, 36) + (_recommandedDef - charactor.Defend);

            if ((_recommandedDef > charactor.Defend && random.Next(1,100) > 25) || _recommandedDef > charactor.Health)
            {
                //공략 실패
                Console.WriteLine("던전 공략 실패");
                Console.WriteLine("던전 공략에 실패했습니다.\n");
                getReward = 0;
                minusHp = 50;
                if(minusHp > charactor.Health)
                    minusHp = charactor.Health;
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
            int nextExp = charactor.Exp + getExp;
            int level = charactor.Level;
            if(nextExp >= 200)
            {
                Console.WriteLine("레벨업 하였습니다!\n");
                level++;
                charactor.Attack++;
                charactor.Defend += 2;
                nextExp -= 200;
            }

            float rewardPercent = (random.Next(charactor.Attack, (charactor.Attack*2) + 1) + 100) / 100.0f;
            int totalReward = (int) (getReward * rewardPercent);
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {charactor.Health} -> {charactor.Health - minusHp}");
            Console.WriteLine($"Gold {charactor.Gold} -> {charactor.Gold + totalReward}");
            Console.WriteLine($"레벨 {charactor.Level} -> {level}");
            Console.WriteLine($"경험치 {charactor.Exp} -> {nextExp}");
            charactor.Health = charactor.Health - minusHp;
            charactor.Gold = charactor.Gold + totalReward;

            // 캐릭터 사망
            if(charactor.Health == 0)
            {
                Console.WriteLine("\n캐릭터가 사망했습니다.");
                Console.WriteLine("게임 오버");
            }

            Console.WriteLine("\n0. 나가기\n");

            choice = base.Choice(0, true);
        }

        // 전투 시작
        void StartBattle(DungeonLv dungeonLevel)
        {
            // 몬스터 생성
            Monster[] monsters = CreateMonsters(dungeonLevel);

            if (monsters != null)
            {
                // 전투 시작
                Battle battle = new Battle(new Player(charactor), monsters);
                battle.StartBattle();
            }
            else
            {
                Console.WriteLine("몬스터를 생성하는 데 문제가 발생했습니다.");
            }
        }

        // 던전 레벨에 따라 몬스터 생성
        Monster[] CreateMonsters(DungeonLv dungeonLevel)
        {
            switch (dungeonLevel)
            {
                case DungeonLv.쉬움:
                    return new Monster[]
                    {
                          new Monster("미니언", 15, 5),
                          new Monster("대포미니언", 25, 8),
                          new Monster("공허충", 10, 9)
                    };
                case DungeonLv.일반:
                    return new Monster[]
                    {
                        new Monster("미니언", 15, 5),
                        new Monster("대포미니언", 25, 8),
                        new Monster("공허충", 10, 9)
                    };
                case DungeonLv.어려움:
                    return new Monster[]
                    {
                        new Monster("미니언", 15, 5),
                        new Monster("대포미니언", 25, 8),
                        new Monster("공허충", 10, 9)
                    };
                default:
                    throw new ArgumentException("올바르지 않은 던전 레벨입니다.");
            }
        }
    }
    enum DungeonLv
    {
        쉬움=1, 일반, 어려움
    }
}
