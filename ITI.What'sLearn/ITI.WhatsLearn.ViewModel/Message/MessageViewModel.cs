using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public  class MessageViewModel
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }

    }
}
