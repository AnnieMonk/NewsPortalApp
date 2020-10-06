using System;
using System.Collections.Generic;

namespace NewsPortal.Database
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
