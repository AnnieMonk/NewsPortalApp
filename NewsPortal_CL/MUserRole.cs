using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal_CL
{
    public class MUserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime DateCreated { get; set; }
       // public virtual MRole Role { get; set; }
    }
}
