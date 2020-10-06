using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal_CL.Request
{
    public class AccountInsertRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }

        public List<int> Roles { get; set; } = new List<int>();
    }
}
