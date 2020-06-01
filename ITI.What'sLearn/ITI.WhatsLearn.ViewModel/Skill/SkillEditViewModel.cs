using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class SkillEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required][MaxLength(250)]
        public string skill { get; set; }

    }
}
