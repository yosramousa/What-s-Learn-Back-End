using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class ManageUserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<String> TracksName { get; set; }
        public string Status { get; set; }
    }
}
