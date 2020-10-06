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
    public class RoleService : BaseService<MRole, RoleSearchRequest, Database.Role>
    {
        public RoleService(SoftraySolutionsContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
