using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class DashBoardViewModel
    {
        public int UserCount { get; set; }
        public int MainCategoryCount { get; set; }
        public int TracksCount { get; set; }
        public Dictionary<string, int> UserInEachTrack { get; set; }

        
    }
}
