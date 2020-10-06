using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Services;

namespace NewsPortal.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TSearch> : ControllerBase 
    {
        protected IService<TModel, TSearch> _service;

        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult<List<TModel>> GetAll([FromQuery] TSearch request = default)
        {
            return Ok(_service.GetAll(request));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public virtual ActionResult<TModel> GetById(int id)
        {
            if (_service.GetById(id) != null)
                return Ok(_service.GetById(id));
            else
                return NotFound();
        }
    }
}
