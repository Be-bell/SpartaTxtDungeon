using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("\n[플레이어의 턴]");
            Console.WriteLine("1. 공격");

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    PlayerAttack();
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
            Console.WriteLine("\n[플레이어의 공격]");
            foreach (var monster in monsters1)
            {
                monster.TakeDamage(player.ATK);
                Console.WriteLine($"{monster.Name}에게 {player.ATK}의 피해를 입혔습니다.");
            }

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
                    player.TakeDamage(monster.ATK);
                    Console.WriteLine($"{monster.Name}의 공격! 플레이어가 {monster.ATK}의 피해를 입었습니다.");
                }
            }

            DisplayBattleStatus(player, monsters1); // 전투 상태 표시
            PlayerTurn(); // 플레이어의 턴으로 돌아감
        }

        // 전투 상태 표시 메서드
        private void DisplayBattleStatus(Player player, Monster[] monsters)
        {
            Console.WriteLine("\n[전투 상태]");
            Console.WriteLine("플레이어 체력: " + player.HP);

            for (int i = 0; i < monsters.Length; i++)
            {
                Console.WriteLine($"{monsters[i].Name} 체력: {monsters[i].HP}");
            }
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
            return choice;
        }
    }
}
