using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class  TrackDocument : BaseModel
    {
        public string File { get; set; }
        public string Description { get; set; }
        public virtual Track Track { get; set; }
        public int TrackID { get; set; }

    }
}
