namespace ITI.WhatsLearn.Entities
{
    public class UserSkill : BaseModel
    {
        public virtual User User { get; set; }

        public int UserID { get; set; }

        public virtual Skill Skill { get; set; }

        public int SkillID { get; set; }
        public int Level { get; set; }

    }
}
