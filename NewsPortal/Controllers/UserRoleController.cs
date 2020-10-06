using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Services;
using NewsPortal_CL;
using NewsPortal_CL.Request;

namespace NewsPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : BaseController<MUserRole, UserRoleSearchRequest>
    {
        public UserRoleController(IService<MUserRole, UserRoleSearchRequest> service) : base(service)
        {
        }
    }
}
