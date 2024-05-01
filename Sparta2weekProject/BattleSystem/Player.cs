using Sparta2weekProject.Objects;
using System;
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

        // 생성자
        public Player(string name, int level, int hp, int atk)
        {
            Name = name;
            Level = level;
            HP = hp;
            ATK = atk;
        }

        public Player(Charactors charactor)
        {
            this.charactor = charactor;
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
