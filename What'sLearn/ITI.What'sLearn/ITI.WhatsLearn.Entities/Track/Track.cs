using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class Track
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual SubCategory SubCategory { get; set; }
        public int SubCategoryID { get; set; }

        public virtual ICollection<TrackDocument> TrackDocuments { get; set; }
        public virtual ICollection<TrackLink> Trackinks { get; set; }
        public virtual ICollection<TrackVedio> TrackVedios { get; set; }
        public virtual ICollection<UserTrack> Users { get; set; }
    }
}
