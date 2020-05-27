using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class AdminEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
