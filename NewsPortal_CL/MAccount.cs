using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal_CL
{
    public class MAccount
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PassHash { get; set; }
        public string PassHsalt { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }

        public virtual MUser User { get; set; }
    }
}
