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
        [Required]
        public int ID { get; set; }
        [Required]

        public int UserID { get; set; }
        [Required]

        public int SkillID { get; set; }
        [Required]

        public int Level { get; set; }
    }
}
