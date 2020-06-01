﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class CourseVedioEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Vedio { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public int ParentID { get; set; }


    }
}