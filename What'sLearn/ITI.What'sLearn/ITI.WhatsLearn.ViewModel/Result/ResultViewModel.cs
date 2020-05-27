using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class ResultViewModel<T>
    {
        public bool Successed { get; set; } = false;
        public T Data { get; set; }
        public string Message { get; set; } = "";
    }
}
