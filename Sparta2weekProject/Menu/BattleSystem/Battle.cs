using Sparta2weekProject.Objects.Charactor;
using System;
using System.Threading;

namespace Sparta2weekProject.Menu.BattleSystem
{
    // 전투 클래스
    public class Battle : GameManager
    {

        public Battle(Charactor _charactor, Monster[] _monsters)
        {
            charactor = _charactor;
            monsters = _monsters;
        }

        // 전투 시작 메서드
        public void InBattle()
        {
            charactor.KillCount = 0;
            PlayerTurn(); // 플레이어의 턴 시작
        }

        // 플레이어 턴 메서드
        private void PlayerTurn()
        {
            #region ConsolePrint
            DisplayMonsters(false);
            DisplayPlayerInfo();
            Console.WriteLine($"\n{charactor.Name}의 턴");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬");
            Console.Write(">> ");
            #endregion ConsolePrint

            int choice = GetChoice();


            switch (choice)
            {
                case 1:
                    PlayerAttack();
                    break;
                case 2:
                    PlayerSkill();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    PlayerTurn();
                    return;
            }
            if (!MonsterAllDead())
            {
                EnemyTurn();
                return;
            }
        }

        private bool MonsterAllDead()
        {
            
            if (charactor.KillCount == monsters.Length)
            {
                // 플레이어 마나 회복
                charactor.RecoverMana(10);
                return true;
            }

            return false;
        }

        // 플레이어 공격 메서드
        private void PlayerAttack()
        {
            

            DisplayMonsters(true);
            DisplayPlayerInfo();

            Console.WriteLine("공격할 몬스터를 선택하세요.");
            Console.WriteLine("0. 돌아가기");
            int choice = GetChoice();

            if (choice < 0 || choice > monsters.Length)
            {
                Console.WriteLine("잘못 지정하였습니다. 다시 선택해주세요.\n");
                PlayerAttack();
                return;
            }
            else if (choice == 0)
            {
                PlayerTurn();
                return;
            }

            Monster monster = monsters[choice - 1];

            // 선택한 몬스터가 이미 죽어있으면
            if (monster.IsDead())
            {
                Console.WriteLine("이미 죽은 몬스터입니다.\n");
                PlayerAttack();
                return;
            }

            Console.WriteLine($"[{charactor.Name} 의 공격]");
            int damage = charactor.Attack + charactor.PlusAttack;

            Thread.Sleep(500);

            // 치명타 여부 확인
            if (IsCritical())
            {
                damage = (int)(damage * 1.6); // 데미지 160% 증가
                Console.WriteLine($"{charactor.Name} 의 공격! {monster.Name}에게 치명타 공격! {damage}의 피해를 입혔습니다.");
            }
            else
            {
                Console.WriteLine($"{charactor.Name} 의 공격! {monster.Name}에게 {damage}의 피해를 입혔습니다.");
            }

            // 공격 처리
            monster.TakeDamage(damage);
            if(monster.IsDead())
            {
                switch (monster.Name)
                {
                    case "미니언":
                        charactor.MinionCount++;
                        break;
                    case "대포미니언":
                        charactor.CannonCount++;
                        break;
                    case "공허충":
                        charactor.vacuityCount++;
                        break;
                }
                charactor.KillCount++;
            }

            Thread.Sleep(500);
        }

        // 적 턴 메서드
        private void EnemyTurn()
        {
            Console.WriteLine("\n[적의 턴]");

            foreach (var monster in monsters)
            {
                if (!monster.IsDead())
                {
                    Console.WriteLine($"{monster.Name}의 공격!");
                    Thread.Sleep(500);
                    // 회피 여부 확인
                    if (IsDodge())
                    {
                        Console.WriteLine($"{monster.Name}의 공격을 회피했습니다.");
                    }
                    else if (charactor.TakeDamage(monster.ATK-charactor.Defend))
                    {
                        Console.WriteLine($"{charactor.Name}가 {monster.ATK}의 피해를 입었습니다.");

                    }
                    Thread.Sleep(500);
                    //캐릭터가 죽으면 리턴함.
                    if (charactor.HP == 0)
                    {
                        return;
                    }
                    
                }
            }

            Console.Clear();


            PlayerTurn(); // 플레이어의 턴으로 돌아감
            return;
        }

        // 치명타 여부를 결정하는 메서드
        private static bool IsCritical()
        {
            Random random = new Random();

            //1부터 100까지의 난수
            int chance = random.Next(1, 101); 

            //15% 확률로 치명타 발생
            return chance <= 15; 
        }

        // 회피 여부를 결정하는 메서드
        private static bool IsDodge()
        {
            Random random = new Random();

            //1부터 100까지의 난수
            int chance = random.Next(1, 101); 

            //10% 확률로 회피 발생
            return chance <= 10; 
        }

        // 사용자 입력 처리 메서드
        private int GetChoice()
        {
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("숫자를 입력하세요.");
                return GetChoice();
            }
            Console.Clear();
            return choice;
        }

        //플레이어 스킬 메서드
        private void PlayerSkill()
        {
            DisplayMonsters(false);
            DisplayPlayerInfo();
            Console.WriteLine("[스킬 선택]");
            SkillBook skills = charactor.SkillBook;
            skills.SkillsPrint();
            int choice = GetChoice();
            bool skillUse = false;

            switch (choice)
            {
                case 1:
                    skillUse = charactor.SkillUse(skills.skill_1, charactor, monsters);
                    if (!skillUse) PlayerSkill();
                    break;
                case 2:
                    skillUse = charactor.SkillUse(skills.skill_2, charactor, monsters);
                    if (!skillUse) PlayerSkill();
                    break;
                case 0:
                    PlayerTurn(); // 플레이어의 턴으로 돌아감
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    PlayerSkill();
                    break;
            }
        }
    }
}

