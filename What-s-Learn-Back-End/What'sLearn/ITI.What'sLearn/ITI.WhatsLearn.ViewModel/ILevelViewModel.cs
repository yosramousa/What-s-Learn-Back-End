using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public interface ILevelViewModel
    {
         int ID { get; set; }
         string Name { get; set; }
         List<ILevelViewModel> Childs { get; set; }
         ILevelViewModel Parent { get; set; }
    }
}
