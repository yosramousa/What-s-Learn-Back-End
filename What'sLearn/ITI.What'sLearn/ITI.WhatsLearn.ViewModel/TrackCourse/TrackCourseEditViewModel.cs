using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class TrackCourseEditViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int TrackID { get; set; }

        [Required]
        public int CourseID { get; set; }


    }
}
