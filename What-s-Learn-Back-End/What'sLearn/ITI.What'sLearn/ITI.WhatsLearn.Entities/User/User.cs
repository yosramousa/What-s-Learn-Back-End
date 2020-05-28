
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Entities
{
    public  class User:Person
    {
        public string Education { get; set; }
        public DateTime SignedTime { get; set; } = DateTime.Now;

        public virtual ICollection<UserCertificate> Certificates { get; set; }
        public virtual ICollection<UserSocialLink> SocialLinks { get; set; }
        public virtual ICollection<UserSkill> Skills { get; set; }
        public virtual ICollection<UserTrack> Tracks { get; set; }
    }
}
