using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.ViewModel
{
    public class MessageEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
      //  [Required]
        public DateTime SendTime { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
        public bool IsRead { get; set; } = false;


    }
}
