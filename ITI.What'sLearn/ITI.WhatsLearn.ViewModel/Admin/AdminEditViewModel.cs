using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class AdminEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(250)]
        public string Adress { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Phone { get; set; }

        public bool IsActive { get; set; } 

        public string Image { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
