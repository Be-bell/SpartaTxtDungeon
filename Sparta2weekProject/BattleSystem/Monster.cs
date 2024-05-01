﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta2weekProject.BattleSystem
{
    // 몬스터 클래스
    public class Monster
    {
        private string v1;
        private int v2;
        private int v3;

        // 필드
        public string Name { get; } // 몬스터 이름
        public int Level { get; } // 몬스터 레벨
        public int HP { get; private set; } // 몬스터 체력
        public int ATK { get; } // 몬스터 공격력

        // 생성자
        public Monster(string name, int level, int hp, int atk)
        {
            Name = name;
            Level = level;
            HP = hp;
            ATK = atk;
        }

        public Monster(string v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        // 몬스터가 피해를 받는 메서드
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{Name}이(가) 사망했습니다.");
                Console.ResetColor();
            }
        }

        // 몬스터가 죽었는지 확인하는 메서드
        public bool IsDead()
        {
            return HP <= 0;
        }
    }

    // 몬스터 정보 정의
    public static class MonsterInfo
    {
        public static Monster Lv2_Minion => new Monster("Lv2 미니언", 2, 15, 5);
        public static Monster Lv3_VoidBug => new Monster("Lv3 공허충", 3, 10, 9);
        public static Monster Lv5_CannonMinion => new Monster("Lv5 대포미니언", 5, 25, 8);
    }
}
