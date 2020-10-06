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
    public class PostController : BaseCRUDController<MPost, PostSearchRequest, PostUpdateRequest, PostInsertRequest>
    {
        public PostController(ICRUDService<MPost, PostSearchRequest, PostUpdateRequest, PostInsertRequest> service) : base(service)
        {
        }


    }
}
