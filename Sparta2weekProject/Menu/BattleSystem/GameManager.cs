using Sparta2weekProject.Objects.Charactor;

namespace Sparta2weekProject.Menu.BattleSystem
{
    // 게임 관리자 클래스
    public class GameManager
    {
        protected Monster[] monsters; // 몬스터 리스트
        protected Charactor charactor; // 플레이어 객체

        // 생성자
        //public GameManager(Charactor _charactor, Monster[] _monsters)
        //{
        //    this.monsters = _monsters;
        //    this.charactor = _charactor;
        //}

        // 게임 시작 메서드
        //public void StartGame()
        //{
        //    // 게임 시작 로직 구현
        //    Console.WriteLine("Battle!!");
        //    DisplayMonsters();
        //    DisplayPlayerInfo();
        //    StartBattle();
        //}

        // 전투 시작 메서드
        //private void StartBattle()
        //{
        //    Battle battle = new Battle(monsters, charactor);
        //    battle.StartBattle();
        //}

        // 몬스터 정보 출력 메서드
        protected void DisplayMonsters(bool _isBattle)
        {

            Console.WriteLine("\n몬스터 정보");
            for (int i = 0; i < monsters.Length; i++)
            {
                Monster monster = monsters[i];
                string number = _isBattle == true ? $" [{i + 1}]" : "";
                string isDead = monster.IsDead() ? "[Dead] " : "";
                Console.WriteLine($"{number}{monster.Name} / HP : {monster.HP} / ATK : {monster.ATK}{isDead}");
            }
        }

        // 플레이어 정보 출력 메서드
        protected void DisplayPlayerInfo()
        {
            Console.WriteLine("\n[내정보]");
            Console.WriteLine($"Lv. {charactor.Level} / {charactor.Name} ({charactor.Class})");
            Console.WriteLine($"HP : {charactor.HP} / {charactor.FullHP}");
            Console.WriteLine($"MP : {charactor.MP} / {charactor.FullMP}\n");
        }
    }
}
