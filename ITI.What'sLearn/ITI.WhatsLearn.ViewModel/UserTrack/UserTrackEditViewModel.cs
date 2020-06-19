using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserTrackEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int UserID{ get; set; }
        [Required]
        public int TrackID{ get; set; }
        [Required]
        public DateTime Date { get; set; }
     //   [Required]
        public DateTime FinshDate { get; set; }

        //  [Required]
        public bool IsApproveed { get; set; } = false;
        public int? UserCount { get; set; }

    }
}
