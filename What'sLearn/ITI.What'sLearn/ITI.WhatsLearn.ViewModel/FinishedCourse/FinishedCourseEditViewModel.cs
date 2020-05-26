using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class FinishedCourseEditViewModel
    {
        public int ID { get; set; }

        [Required]
        public int TrackID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int CourseID { get; set; }
        public int UserTrackID { get; set; }
    }
}
