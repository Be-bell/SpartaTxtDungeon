﻿
using Sparta2weekProject.Menu;

namespace Sparta2weekProject.Objects
{
    public class Charactors
    {
        // 각종 스텟
        public int Level;
        public CharactorClass Class;
        public int Attack;
        public int Defend;
        public int FullHealth;
        public int Health;
        public int Gold;
        public int Exp;
        public int PlusAttack = 0;
        public int PlusDefend = 0;

  

        // 인벤토리
        public List<Items> Inven;

        public List<Portion> Portion;

        // 장착 무기
        public Items? Armor;
        public Items? Weapon;
        public Items? Portions;

        // 직업 생성 시 lv. 1, gold 1000부터 시작, 인벤토리 제작.
        public Charactors(CharactorClass _charactorClass)
        {
            Class = _charactorClass;
            Level = 1;
            Gold = 1000;
            Exp = 0;
            
          

            switch (_charactorClass)
            {
                case CharactorClass.전사:
                    Attack = 10;
                    Defend = 20;
                    FullHealth = 150;
                    Health = 150;
                    break;
                case CharactorClass.궁수:
                    Attack = 15;
                    Defend = 15;
                    FullHealth = 100;
                    Health = 100;
                    break;
            }

            Inven = new List<Items>();
            Portion = new List<Portion>();
            for (int i = 0; i < 3; i++)
            {
                Portion.Add(new PortionHP(100, 0, 0));

            }
        }
      
       
    }

    public enum CharactorClass
    {
        전사, 궁수
    }
}
