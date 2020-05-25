using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class AdminEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public string Image { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
