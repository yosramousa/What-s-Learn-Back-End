using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserSocialLink:BaseModel
    {
        public string link { get; set; }

        public virtual User User { get; set; }
        public int UserID { get; set; } 

    }
}
