﻿using ITI.WhatsLearn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public class Course : BaseModel
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
       public string Icon { get; set; }
        public virtual ICollection<CourseLink> CourseLinks { get; set; }
        public virtual ICollection<CourseDocument> CourseDocuments { get; set; }
        public virtual ICollection<CourseVedio> CourseVedios { get; set; }
        public virtual ICollection<TrackCourse> Tracks { get; set; }
        public virtual ICollection<FinishedCourse>  UserTracks { get; set; }

    }
}
