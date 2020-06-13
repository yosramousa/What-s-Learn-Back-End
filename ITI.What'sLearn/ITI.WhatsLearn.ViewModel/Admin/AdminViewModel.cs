using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class AdminViewModel
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } 
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
