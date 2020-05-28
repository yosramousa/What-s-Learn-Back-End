using System;
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
        public char Gender { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } 
        public string Image { get; set; }
        public bool IsDeleted { get; set; }

        public List<TrackViewModel> Tracks { get; set; }
<<<<<<< HEAD:What-s-Learn-Back-End/What-s-Learn-Back-End/What'sLearn/ITI.What'sLearn/ITI.WhatsLearn.ViewModel/User/UserViewModel.cs
        public DateTime SignedTime { get; set; } 

=======
>>>>>>> b1df7ede4a62a97a9a2169d7bb14264b51a28b29:What-s-Learn-Back-End/What'sLearn/ITI.What'sLearn/ITI.WhatsLearn.ViewModel/User/UserViewModel.cs
    }
}
