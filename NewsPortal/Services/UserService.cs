using AutoMapper;
using NewsPortal.Database;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class UserService : BaseService<MUser, UserSearchRequest, Database.User>
    {
        public UserService(SoftraySolutionsContext context, IMapper mapper) : base(context, mapper)
        {
        }

       
    }
}
