using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public interface IAccount
    {
        MAccount GetLoggedUser();
        List<MAccount> GetAll(AccountSearchRequest search);

        MAccount GetById(int id);

        MAccount Insert(AccountInsertRequest request);


        MAccount Login(AccountSearchRequest search);
    }
}
