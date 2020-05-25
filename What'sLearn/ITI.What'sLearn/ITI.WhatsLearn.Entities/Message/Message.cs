using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class Message :BaseModel
    {
        public String FullName { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsRead { get; set; }


    }
}
