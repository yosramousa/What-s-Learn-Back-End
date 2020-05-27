using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserCertificateViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual string UserName { get; set; }
 
    }
}
