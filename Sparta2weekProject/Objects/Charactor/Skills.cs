using Sparta2weekProject.Interfaces;
using Sparta2weekProject.Menu.BattleSystem;

namespace Sparta2weekProject.Objects.Charactor
{
    public abstract class Skills : ISkill
    {
        public int requiredMP { get; protected set; }
        public string skillName { get; protected set; }
        public string Description { get; protected set; }

        protected Monster[] monsters;
        protected Charactor charactor;

        public string SkillInfo()
        {
            return string.Format(skillName + " - MP " + requiredMP + "\n" + Description);
        }

        protected int ChooseMonsterToAttack()
        {
            Console.WriteLine("타겟을 선택해주세요.");
            Console.WriteLine("0. 돌아가기");
            int choice = GetChoice();
            return choice;
        }

        protected int GetChoice()
        {
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("숫자를 입력하세요.");
                return GetChoice();
            }
            Console.Clear();
            return choice;
        }

        public abstract bool IsUse(Charactor _charactor,Monster[] _targets);

    }

    public class WarriorSkill_1 : Skills
    {
        public WarriorSkill_1()
        {
            requiredMP = 10;
            skillName = "알파 스트라이크";
            Description = "공격력 * 2 로 하나의 적을 공격합니다.";
        }

        public override bool IsUse(Charactor _charactor, Monster[] _targets)
        {
            Console.WriteLine("\n몬스터 정보");
            monsters = _targets;
            charactor = _charactor;

            for (int i = 0; i < monsters.Length; i++)
            {
                Monster monster = monsters[i];
                string isDead = monster.IsDead() ? "[Dead] " : "";
                Console.WriteLine($"[{i + 1}] {monster.Name} / HP : {monster.HP} / ATK : {monster.ATK}{isDead}");
            }

            Console.WriteLine("\n[내정보]");
            Console.WriteLine($"Lv. {charactor.Level} / {charactor.Name} ({charactor.Class})");
            Console.WriteLine($"HP : {charactor.HP} / {charactor.FullHP}");
            Console.WriteLine($"MP : {charactor.MP} / {charactor.FullMP}\n");

            int choice = ChooseMonsterToAttack();

            if(choice == 0)
            {
                return false;
            }
            else if(choice<0 || choice > monsters.Length)
            {
                Console.WriteLine("잘못 선택하였습니다. 다시 입력해주세요.");
                return IsUse(charactor, monsters);
            }

            int damage = charactor.Attack * 2;

            Monster target = monsters[choice - 1];
            if(target.IsDead())
            {
                Console.WriteLine("이미 죽은 대상입니다.");
                return IsUse(charactor, monsters);
            }

            Console.WriteLine($"{charactor.Name} 의 공격! {target.Name}에게 알파 스트라이크! {damage}의 피해를 입혔습니다.");
            charactor.MP -= requiredMP;
            target.TakeDamage(damage);

            return true;
        }
    }

    public class WarriorSkill_2 : Skills
    {
        public WarriorSkill_2()
        {
            requiredMP = 15;
            skillName = "더블 스트라이크";
            Description = "공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.";
        }

        public override bool IsUse(Charactor _charactor, Monster[] _targets)
        {
            monsters = _targets;
            charactor = _charactor;

            if(monsters.Length < 2) 
            {
                return false;
            }

            int[] randoms = TwoRandomSelect(monsters.Length);

            int damage = (int) (charactor.Attack * 1.5f);
            
            foreach(var i in randoms)
            {
                Monster target = monsters[i];
                Console.WriteLine($"{charactor.Name} 의 공격! {target.Name}에게 더블 스트라이크! {damage}의 피해를 입혔습니다.");
                target.TakeDamage(damage);
            }
            charactor.MP -= requiredMP;

            return true;
        }

        int[] TwoRandomSelect(int length)
        {
            var random = new Random();
            int[] randomValues = new int[2];
            randomValues[0] = random.Next(0, length);
            do
            {
                randomValues[1] = random.Next(0, length);
            }
            while (randomValues[0] == randomValues[1] );

            return randomValues;
        }
    }

    public class ArchorSkill_1 : Skills
    {
        public ArchorSkill_1()
        {
            requiredMP = 15;
            skillName = "비장의 한발";
            Description = "공격력 * 2 로 하나의 적을 공격합니다.";
        }

        public override bool IsUse(Charactor _charactor, Monster[] _targets)
        {
            Console.WriteLine("\n몬스터 정보");
            monsters = _targets;
            charactor = _charactor;

            for (int i = 0; i < monsters.Length; i++)
            {
                Monster monster = monsters[i];
                string isDead = monster.IsDead() ? "[Dead] " : "";
                Console.WriteLine($"[{i + 1}] {monster.Name} / HP : {monster.HP} / ATK : {monster.ATK}{isDead}");
            }

            Console.WriteLine("\n[내정보]");
            Console.WriteLine($"Lv. {charactor.Level} / {charactor.Name} ({charactor.Class})");
            Console.WriteLine($"HP : {charactor.HP} / {charactor.FullHP}");
            Console.WriteLine($"MP : {charactor.MP} / {charactor.FullMP}\n");

            int choice = ChooseMonsterToAttack();

            if (choice == 0)
            {
                return false;
            }
            else if (choice < 0 || choice > monsters.Length)
            {
                Console.WriteLine("잘못 선택하였습니다. 다시 입력해주세요.");
                return IsUse(charactor, monsters);
            }

            int damage = charactor.Attack * 2;

            Monster target = monsters[choice - 1];
            if (target.IsDead())
            {
                Console.WriteLine("이미 죽은 대상입니다.");
                return IsUse(charactor, monsters);
            }

            Console.WriteLine($"{charactor.Name} 의 공격! {target.Name}에게 비장의 한발! {damage}의 피해를 입혔습니다.");
            charactor.MP -= requiredMP;
            target.TakeDamage(damage);

            return true;
        }
    }

    public class ArchorSkill_2 : Skills
    {
        public ArchorSkill_2()
        {
            requiredMP = 40;
            skillName = "화살세례";
            Description = "공격력 * 1.2 로 모든 적을 공격합니다.";
        }

        public override bool IsUse(Charactor _charactor, Monster[] _targets)
        {
            monsters = _targets;
            charactor = _charactor;

            int damage = (int) (charactor.Attack * 1.2f);

            foreach (var target in monsters)
            {
                Console.WriteLine($"{charactor.Name} 의 공격! {target.Name}에게 화살세례! {damage}의 피해를 입혔습니다.");
                target.TakeDamage(damage);
            }
            charactor.MP -= requiredMP;

            return true;
        }
    }

}
