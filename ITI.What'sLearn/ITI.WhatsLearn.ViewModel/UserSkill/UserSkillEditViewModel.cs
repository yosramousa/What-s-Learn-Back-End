using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserSkillEditViewModel
    {
        
        public int ID { get; set; } = 0;
        [Required]

        public int UserID { get; set; }
        [Required]

        public int SkillID { get; set; }

        public string SkillName { get; set; }


        public int Level { get; set; } = 5;
        public bool IsDeleted { get; set; } = false;

    }
}
