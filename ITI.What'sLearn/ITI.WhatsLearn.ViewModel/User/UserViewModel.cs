﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Education { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } 
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public List<TrackViewModel> Tracks { get; set; }
        public List<UserSkillViewModel> Skills { get; set; }
        public List<UserCertificateViewModel> Certificates { get; set; }
        public List<UserSocialLinkViewModel> SocialLinks { get; set; }
        public DateTime SignedTime { get; set; } 
    }
}
