using Sparta2weekProject.Interfaces;

namespace Sparta2weekProject.Objects
{
    public class Skills : ISkill
    {
        public int requiredMP { get; protected set; }
        public string skillName { get; protected set; }
        public string skillInfo { get; protected set; }

        public string SkillInfo()
        {
            return String.Format(skillName + " - MP " + requiredMP + "\n" + skillInfo);
        }
    }

    public class WarriorSkill_1 : Skills
    {
        public WarriorSkill_1()
        {
            requiredMP = 10;
            skillName = "알파 스트라이크";
            skillInfo = "공격력 * 2 로 하나의 적을 공격합니다.";
        }
    }

    public class WarriorSkill_2 : Skills
    {
        public WarriorSkill_2()
        {
            requiredMP += 15;
            skillName = "더블 스트라이크";
            skillInfo = "공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.";
        }
    }

    public class ArchorSkill_1 : Skills
    {
        public ArchorSkill_1()
        {
            requiredMP = 15;
            skillName = "비장의 한발";
            skillInfo = "공격력 * 2 로 하나의 적을 공격합니다.";
        }
    }

    public class ArchorSkill_2 : Skills
    {
        public ArchorSkill_2()
        {
            requiredMP = 40;
            skillName = "화살세례";
            skillInfo = "공격력 * 1.2 로 모든 적을 공격합니다.";
        }
    }

}
