﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserCertificateEditViewModel
    {

        public int ID { get; set; } = 0;
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public virtual int UserID{ get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Image { get; set; } 
    }
}
