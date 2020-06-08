using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserSocialLinkEditViewModel
    {
        public int ID { get; set; } = 0;
        public string Link { get; set; }

        public int UserID { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
