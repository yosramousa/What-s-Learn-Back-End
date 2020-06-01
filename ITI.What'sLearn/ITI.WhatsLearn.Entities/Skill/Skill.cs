
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public  class Skill:BaseModel
    {
        public string skill { get; set; }
        public virtual ICollection<UserSkill> Skills { get; set; }

    }
}
