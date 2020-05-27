using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.WhatsLearn.Presentation
{
    public class ResultViewModel<T>
    {
        public bool Successed { get; set; } = false;
        public T Data { get; set; } 
        public string Message { get; set; } = "";
    }
}