using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class UserCertificate : BaseModel
    {
        public string Title { get; set; }
        public virtual User User { get; set; }
        public int  UserID { get; set; }
        public string Image { get; set; }



    }
}
