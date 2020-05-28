using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserTrackViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string TrackName { get; set; }
        public DateTime Date { get; set; }
        public int Progress { get; set; }
        public int UserCount { get; set; }
        public int TrackCount { get; set; }
        public bool IsApproveed { get; set; } = false;
    }
}
