using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.WhatsLearn.ViewModel
{
    public class LoginModel
    {
      
        public int ID { get;set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
        public string Role { get; set; }

    }
}