using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserSkillViewModel
    {
        public int ID { get; set; }
        public int SkillID { get; set; }

        public string UserName { get; set; }
        public int UserID { get; set; }
        public string SkillName { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
