﻿using System;
using System.Collections.Generic;

namespace NewsPortal.Database
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
