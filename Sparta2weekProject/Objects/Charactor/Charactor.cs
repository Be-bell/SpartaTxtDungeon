using Sparta2weekProject.Menu;
using Sparta2weekProject.Menu.BattleSystem;

namespace Sparta2weekProject.Objects.Charactor
{
    public class Charactor
    {
        // 이름
        public string Name;

        // 각종 스텟
        public int Level;
        public CharactorClass Class;
        public int Attack;
        public int Defend;
        public int FullHP;
        public int HP;
        public int Gold;
        public int Exp;
        public int PlusAttack = 0;
        public int PlusDefend = 0;
        public int MP;
        public int FullMP;
        public int MinionCount; // 미니언 킬 수
        public int CannonCount; // 대포미니언 킬 수
        public int vacuityCount; // 공허충 킬 수
        public int KillCount;   // 던전 입장 시 킬카운트
        // 인벤토리
        public List<Items> Inven;

        public List<Portion> PortionHP = new List<Portion>();
        public List<Portion> PortionAtk = new List<Portion>();
        public List<Portion> PortionDef = new List<Portion>();



        // 장착 Weapon
        public Items? Armor;
        public Items? Weapon;

        // 스킬북
        public SkillBook SkillBook;

        // 직업 생성 시 lv. 1, gold 1000부터 시작, 인벤토리 제작.
        public Charactor(CharactorClass _charactorClass)
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
                    FullHP = 150;
                    HP = 150;
                    FullMP = 100;
                    MP = 30;
                    SkillBook = new WarriorSkillBook();
                    break;
                case CharactorClass.궁수:
                    Attack = 15;
                    Defend = 15;
                    FullHP = 100;
                    HP = 100;
                    MP = 80;
                    FullMP = 80;
                    SkillBook = new ArchorSkillBook();
                    break;
            }

            Inven = new List<Items>();


            for (int i = 0; i < 3; i++)
            {
                PortionHP Hpname = new PortionHP(100, 0, 0);
                Hpname.ItemName = "Hp포션";
                PortionHP.Add(Hpname);

            }
        }

        public void NameCreate()
        {
            Console.Write("이름을 입력해주세요: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Name = name;
        }

        public bool SkillUse(Skills _skill, Charactor _charactor, Monster[] _targets)
        {
            Skills skill =  _skill;
            if(_charactor.MP < skill.requiredMP)
            {
                Console.WriteLine("마나가 부족합니다.");
                return false;
            }
            return skill.IsUse(_charactor, _targets);
        }

        // 마나 회복 메서드
        public void RecoverMana(int amount)
        {
            MP += amount;
            // 최대 마나를 초과하지 않도록 확인
            if (MP > FullMP)
            {
                MP = FullMP;
            }
        }

        // 플레이어가 피해를 받는 메서드
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                HP = 0;
                Console.WriteLine("캐릭터가 사망했습니다.");
            }
        }
    }
    public enum CharactorClass
    {
        전사, 궁수
    }
}

