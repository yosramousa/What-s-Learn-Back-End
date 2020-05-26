using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class Track:BaseModel
    {
        
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual SubCategory SubCategory { get; set; }
        public int SubCategoryID { get; set; }

        public virtual ICollection<TrackCourseDocument> TrackCourseDocuments { get; set; }
        public virtual ICollection<TrackCourseLink> TrackCourseLinks { get; set; }
        public virtual ICollection<TrackCourseVedio> TrackCourseVedios { get; set; }
        public virtual ICollection<UserTrackCourse> Users { get; set; }
        public virtual ICollection<TrackCourseCourse> Courses { get; set; }
    }
}
