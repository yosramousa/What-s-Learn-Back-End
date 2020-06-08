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
        public string Icon { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public int SubCategoryID { get; set; }

        public virtual ICollection<TrackDocument> TrackDocuments { get; set; }
        public virtual ICollection<TrackLink> TrackLinks { get; set; }
        public virtual ICollection<TrackVedio> TrackVedios { get; set; }
        public virtual ICollection<UserTrack> Users { get; set; }
        public virtual ICollection<TrackCourse> Courses { get; set; }
    }
}
