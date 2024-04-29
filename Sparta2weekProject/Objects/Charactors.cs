
using Sparta2weekProject.Menu;

namespace Sparta2weekProject.Objects
{
    public class Charactors
    {
        // 각종 스텟
        public int level { get; set; }
        public Chad chad { get; protected set; }
        public int attack { get; set; }
        public int defend { get; set; }
        public int health { get; set; }
        public int fullHealth { get; protected set; }
        public int gold { get; set; }
        public int Exp { get; set; }

        public int plusAttack = 0;
        public int plusDefend = 0;

        // 인벤토리
        public List<Items> inven;

        // 퀘스트
        internal List<QuestInfo> quests;

        // 장착 무기
        public Items? armor;
        public Items? weapon;

        // 직업 생성 시 lv. 1, gold 1000부터 시작, 인벤토리 제작.
        public Charactors(Chad chad)
        {
            level = 1;
            gold = 1000;
            Exp = 0;

            switch (chad)
            {
                case Chad.전사:
                    attack = 10;
                    defend = 20;
                    fullHealth = 150;
                    health = 150;
                    break;
                case Chad.궁수:
                    attack = 15;
                    defend = 15;
                    fullHealth = 100;
                    health = 100;
                    break;
            }

            inven = new List<Items>();
            quests = new List<QuestInfo>();
        }
    }

    public enum Chad
    {
        전사, 궁수
    }
}
