using System;
using System.Runtime.CompilerServices;

namespace Sparta2weekProject.BattleSystem
{
    // 전투 클래스
    public class Battle
    {
        private readonly List<Monster> monsters; // 몬스터 리스트
        private readonly Player player; // 플레이어 객체
        private Monster[] monsters1;

        // 생성자
        public Battle(List<Monster> monsters, Player player)
        {
            this.monsters = monsters;
            this.player = player;
        }

        public Battle(Player player, Monster[] monsters1)
        {
            this.player = player;
            this.monsters1 = monsters1;
        }

        // 전투 시작 메서드
        public void StartBattle()
        {
            DisplayBattleStatus(player, monsters1); // 전투 상태 표시
            PlayerTurn(); // 플레이어의 턴 시작
        }

        // 플레이어 턴 메서드
        private void PlayerTurn()
        {
            Console.WriteLine($"\n{player.Name}의 턴");
            Console.WriteLine($"HP: {player.HP}/{player.FullHealth}\nMP: {player.MP}/{player.MMP}\n");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬");

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
                    break;
            }
        }

        // 플레이어 공격 메서드
        private void PlayerAttack()
        {
            int DeadMonster = 0;
            Console.WriteLine($"\n{player.Name}의 공격]");
            foreach (var monster in monsters1)
            {
                int damage = player.ATK;

                // 치명타 여부 확인
                if (IsCritical())
                {
                    damage = (int)(damage * 1.6); // 데미지 160% 증가
                    Console.WriteLine($"{player.Name}의 공격! {monster.Name}에게 치명타 공격! {damage}의 피해를 입혔습니다.");
                }
                else
                {
                    Console.WriteLine($"{player.Name}의 공격! {monster.Name}에게 {damage}의 피해를 입혔습니다.");
                }

                // 공격 처리
                monster.TakeDamage(damage);

                if (monster.HP == 0) DeadMonster++;
            }

            if (DeadMonster == monsters1.Length)
                // 플레이어 마나 회복
                player.RecoverMana(10); 
            return;

            EnemyTurn(); // 적의 턴으로 넘어감
        }

        // 적 턴 메서드
        private void EnemyTurn()
        {
            Console.WriteLine("\n[적의 턴]");
            foreach (var monster in monsters1)
            {
                if (!monster.IsDead())
                {
                    // 회피 여부 확인
                    if (IsDodge())
                    {
                        Console.WriteLine($"{player.Name}의 공격! {monster.Name}의 공격을 회피했습니다.");
                    }
                    else
                    {
                        player.TakeDamage(monster.ATK);
                        Console.WriteLine($"{monster.Name}의 공격! {player.Name}가 {monster.ATK}의 피해를 입었습니다.");
                    }
                }
            }

            DisplayBattleStatus(player, monsters1); // 전투 상태 표시
            PlayerTurn(); // 플레이어의 턴으로 돌아감
        }

        // 전투 상태 표시 메서드
        private void DisplayBattleStatus(Player player, Monster[] monsters)
        {
            Console.WriteLine("\n[전투 상태]");
            Console.WriteLine($"{player.Name} 체력: " + player.HP);

            for (int i = 0; i < monsters.Length; i++)
            {
                Console.WriteLine($"{monsters[i].Name} 체력: {monsters[i].HP}");
            }
        }

        // 치명타 여부를 결정하는 메서드
        private static bool IsCritical()
        {
            Random random = new Random();
            int chance = random.Next(1, 101); //1부터 100까지의 난수
            return chance <= 15; //15% 확률로 치명타 발생
        }

        // 회피 여부를 결정하는 메서드
        private static bool IsDodge()
        {
            Random random = new Random();
            int chance = random.Next(1, 101); //1부터 100까지의 난수
            return chance <= 10; //10% 확률로 회피 발생
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

        // 플레이어 스킬 메서드
        private void PlayerSkill()
        {
            Console.WriteLine("[스킬 선택]");
            Console.WriteLine("1. 알파 스트라이크 - MP 10");
            Console.WriteLine("   공격력 * 2 로 하나의 적을 공격합니다.");
            Console.WriteLine("2. 더블 스트라이크 - MP 15");
            Console.WriteLine("   공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.");
            Console.WriteLine("0. 취소");

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    player.UseSkill(1, monsters1);
                    break;
                case 2:
                    player.UseSkill(2, monsters1);
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

