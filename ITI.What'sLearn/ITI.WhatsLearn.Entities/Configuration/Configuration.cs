using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class Configuration:BaseModel

    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
