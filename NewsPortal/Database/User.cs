using System;
using System.Collections.Generic;

namespace NewsPortal.Database
{
    public partial class User
    {
        public User()
        {
            Account = new HashSet<Account>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
