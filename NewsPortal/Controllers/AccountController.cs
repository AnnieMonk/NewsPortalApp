using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Services;
using NewsPortal_CL;
using NewsPortal_CL.Request;

namespace NewsPortal.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected IAccount _accountService;

        public AccountController(IAccount accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [Route("[action]")]
        [HttpGet]
        public MAccount GetLoggedUser()
        {
            return _accountService.GetLoggedUser();
        }

      
        [HttpGet]
        [AllowAnonymous]
        public List<MAccount> GetAll([FromQuery] AccountSearchRequest request)
        {
            return _accountService.GetAll(request);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public MAccount GetById(int id)
        {
            return _accountService.GetById(id);
        }

        [HttpPost]
        public MAccount Insert(AccountInsertRequest korisnici)
        {
            return _accountService.Insert(korisnici);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public MAccount Login(AccountSearchRequest request)
        {
            return _accountService.Login(request);
        }

    }
}
