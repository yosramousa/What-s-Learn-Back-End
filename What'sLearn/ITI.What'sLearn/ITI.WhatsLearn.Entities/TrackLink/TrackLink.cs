using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class TrackLink :BaseModel
    {
        public string Link { get; set; }
        public string Description { get; set; }
        public virtual Track Track { get; set; }
        public int TrackID { get; set; }

    }
}
