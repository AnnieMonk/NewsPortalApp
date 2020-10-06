using System;
using System.Collections.Generic;

namespace NewsPortal.Database
{
    public partial class Account
    {
        public Account()
        {
            Post = new HashSet<Post>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PassHash { get; set; }
        public string PassHsalt { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
