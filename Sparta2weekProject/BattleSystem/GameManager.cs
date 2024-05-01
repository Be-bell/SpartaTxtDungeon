using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta2weekProject.BattleSystem
{
    // 게임 관리자 클래스
    public class GameManager
    {
        private readonly List<Monster> monsters; // 몬스터 리스트
        private readonly Player player; // 플레이어 객체

        // 생성자
        public GameManager(List<Monster> monsters, Player player)
        {
            this.monsters = monsters;
            this.player = player;
        }

        // 게임 시작 메서드
        public void StartGame()
        {
            // 게임 시작 로직 구현
            Console.WriteLine("Battle!!");
            DisplayMonsters();
            DisplayPlayerInfo();
            StartBattle();
        }

        // 전투 시작 메서드
        private void StartBattle()
        {
            Battle battle = new Battle(monsters, player);
            battle.StartBattle();
        }

        // 몬스터 정보 출력 메서드
        private void DisplayMonsters()
        {
            Console.WriteLine("\n몬스터 정보");
            foreach (var monster in monsters)
            {
                Console.WriteLine($"{monster.Name} HP {monster.HP} ATK {monster.ATK}");
            }
        }

        // 플레이어 정보 출력 메서드
        private void DisplayPlayerInfo()
        {
            Console.WriteLine("\n[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} (전사)");
            Console.WriteLine($"HP {player.HP}/100\n");
        }
    }
}
