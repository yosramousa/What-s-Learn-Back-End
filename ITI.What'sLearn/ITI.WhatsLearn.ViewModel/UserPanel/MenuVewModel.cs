using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class MenuVewModel
    {
        public  int ID { get; set; }
        public   String  Name{ get; set; }
        public  List<MenuVewModel>  Childs { get; set; }


    }
}
