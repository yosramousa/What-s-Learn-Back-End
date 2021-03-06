﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
 
    public class Person : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public string Image { get; set; }
    
    }
}
