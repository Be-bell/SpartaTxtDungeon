using Sparta2weekProject.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta2weekProject.BattleSystem
{
    // 플레이어 클래스
    public class Player
    {
        private Charactors charactor;

        // 속성
        public string Name { get; } // 플레이어 이름
        public int Level { get; } // 플레이어 레벨
        public int HP { get; private set; } // 플레이어 체력
        public int ATK { get; } // 플레이어 공격력
        public int Def { get; } // 플레이어 방어력

        // 생성자
        public Player(string name, int level, int hp, int atk, int def)
        {
            Name = name;
            Level = level;
            HP = hp;
            ATK = atk;
            Def = def;
        }

        // 생성자
        public Player(Charactors charactor)
        {
            this.charactor = charactor;
            Name = charactor.Name;
            Level = charactor.Level;
            ATK = charactor.Attack;
            Def = charactor.Defend;
            HP = charactor.Health;

            // 캐릭터 클래스에 따라 플레이어 체력 초기화
            // 캐릭터 클래스에서 FullHealth로 초기화되었다고 가정
            //Health = charactor.FullHealth;
        }

        // 플레이어가 피해를 받는 메서드
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                Console.WriteLine("You Lose");
            }
        }
    }
}
