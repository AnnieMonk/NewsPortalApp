using AutoMapper;
using NewsPortal.Database;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class UserRoleService : BaseService<MUserRole, UserRoleSearchRequest, Database.UserRole>
    {
        public UserRoleService(SoftraySolutionsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
