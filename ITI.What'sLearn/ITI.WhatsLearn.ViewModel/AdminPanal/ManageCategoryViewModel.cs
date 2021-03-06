﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class ManageCategoryViewModel
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Parent { get; set; }
        public  string Image { get; set; }
        public virtual List<string> Childs { get; set; }
        public virtual List<string> Users { get; set; }
    }
}
