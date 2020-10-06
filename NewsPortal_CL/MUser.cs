using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal_CL
{
    public class MUser
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<MUserRole> UserRole { get; set; }
    }
}
