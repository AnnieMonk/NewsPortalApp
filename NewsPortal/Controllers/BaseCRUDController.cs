using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Services;

namespace NewsPortal.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<TModel, TSearch, TUpdate, TInsert> : BaseController<TModel, TSearch>
    {
        private readonly ICRUDService<TModel, TSearch, TUpdate, TInsert> _crudService;
        public BaseCRUDController(ICRUDService<TModel, TSearch, TUpdate, TInsert> service) : base(service)
        {
            _crudService = service;
        }
        [HttpDelete("{id}")]
        public ActionResult<TModel> Delete(int id)
        {
            if(_crudService.Delete(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<TModel> Insert(TInsert request)
        {
            try
            {
                var item = _crudService.Insert(request);
                return Ok(item);
            }
            catch
            {
                return NotFound();
            }
              
           
          
            
        }

        [HttpPut("{id}")]
        public ActionResult<TModel> Update(int id, [FromBody] TUpdate request)
        {
            try
            {
                var item = _crudService.Update(id,request);
                return Ok(item);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
