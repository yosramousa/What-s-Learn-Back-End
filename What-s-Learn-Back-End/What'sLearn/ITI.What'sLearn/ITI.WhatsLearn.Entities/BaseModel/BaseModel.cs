using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class BaseModel
    {
        public virtual int ID { get; set; }
        public virtual bool IsDeleted { get; set; }

    }
}
