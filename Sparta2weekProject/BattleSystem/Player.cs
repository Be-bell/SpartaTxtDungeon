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
        public int MP { get; private set; } // 플레이어 MP
        public int FullHealth { get; private set; } // 플레이어 Max  MP
        public int MMP { get; private set; } // 플레이어  Max MP


        // 생성자
        public Player(string name, int level, int hp, int atk, int def, int mp,int mhp, int mmp)
        {
            Name = name;
            Level = level;
            HP = hp;
            ATK = atk;
            Def = def;
            MP = mp;
            FullHealth = mhp;
            MMP = mmp;
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
            MP = charactor.MP;
            MMP= charactor.MMP;
            FullHealth = charactor.FullHealth;
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

        // 스킬 사용 메서드
        public void UseSkill(int skillIndex, Monster[] targets)
        {
            switch (skillIndex)
            {
                case 1:
                    AlphaStrike(targets);
                    break;
                case 2:
                    DoubleStrike(targets);
                    break;
                default:
                    Console.WriteLine("잘못된 스킬 번호입니다.");
                    break;
            }
        }

        // 알파 스트라이크 스킬
        private void AlphaStrike(Monster[] targets)
        {
            if (MP >= 10)
            {
                MP -= 10;
                foreach (var target in targets)
                {
                    int damage = ATK * 2;
                    target.TakeDamage(damage);
                    Console.WriteLine($"{Name}의 알파 스트라이크! {target.Name}에게 {damage}의 피해를 입혔습니다.");
                }
                MP += 10;
            }
            else
            {
                Console.WriteLine("MP가 부족합니다.");
            }
        }

        // 더블 스트라이크 스킬
        private void DoubleStrike(Monster[] targets)
        {
            if (MP >= 15)
            {
                MP -= 15;
                foreach (var target in targets)
                {
                    int damage = (int)(ATK * 1.5);
                    target.TakeDamage(damage);
                    Console.WriteLine($"{Name}의 더블 스트라이크! {target.Name}에게 {damage}의 피해를 입혔습니다.");
                }
                
            }
            else
            {
                Console.WriteLine("MP가 부족합니다.");
            }
        }
        // 마나 회복 메서드
        public void RecoverMana(int amount)
        {
            MP += amount;
            // 최대 마나를 초과하지 않도록 확인
            if (MP > MMP)
            {
                MP = MMP;
            }
        }
    }
}
