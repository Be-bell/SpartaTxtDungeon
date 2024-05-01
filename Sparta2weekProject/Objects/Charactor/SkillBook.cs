namespace Sparta2weekProject.Objects.Charactor
{
    public class SkillBook
    {
        public Skills skill_1 { get; protected set; }
        public Skills skill_2 { get; protected set; }

        public void SkillsPrint()
        {
            Console.WriteLine("[1] " + skill_1.SkillInfo());
        }
    }

    public class WarriorSkillBook : SkillBook
    {
        public WarriorSkillBook()
        {
            skill_1 = new WarriorSkill_1();
            //skill_2 = new WarriorSkill_2();
        }
    }

    public class ArchorSkillBook : SkillBook
    {
        public ArchorSkillBook()
        {
            //skill_1 = new ArchorSkill_1();
            //skill_2 = new ArchorSkill_2();
        }
    }
}
