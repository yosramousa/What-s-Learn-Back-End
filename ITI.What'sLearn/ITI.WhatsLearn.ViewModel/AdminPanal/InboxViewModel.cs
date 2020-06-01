using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class InboxViewModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PriefMessage { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
        public bool IsReaded { set; get; }

    }
}
