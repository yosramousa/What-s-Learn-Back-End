﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
   public  class TrackViewModel: ILevelViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string Image { get; set; }
        public TrackLinkViewModel[] Links { get; set; }
        public TrackDocumentViewModel[] Documents { get; set; }
        public TrackVedioViewModel[] Vedios { get; set; }
        public String SubCategoryName { get; set; }
        public CourseViewModel[] Courses { get; set; }
        public List<CourseViewModel> Childs { get; set ; }
        public SubCategoryViewModel Parent { get; set; }
       



    }
}
