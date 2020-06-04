using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class UserEditViewModel
    {
        
        public int ID { get; set; } = 0;
        public string Education { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime SignedTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string Image { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<UserSkillEditViewModel> Skills { get; set; }
        public List<UserCertificateEditViewModel> Certificates { get; set; }
        public List<UserSocialLinkEditViewModel> SocialLinks { get; set; }

    }
}
