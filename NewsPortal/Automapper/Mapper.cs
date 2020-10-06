using AutoMapper;
using NewsPortal.Database;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Automapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, MUser>().ReverseMap();
            CreateMap<Role, MRole>().ReverseMap();
            CreateMap<UserRole, MUserRole>().ReverseMap();
            CreateMap<Account, MAccount>().ReverseMap();
            CreateMap<Post, MPost>().ReverseMap();

            //for requests:

            CreateMap<Post, PostUpdateRequest>().ReverseMap();
            CreateMap<Post, PostSearchRequest>().ReverseMap();
            CreateMap<Post, PostInsertRequest>().ReverseMap();
            CreateMap<Account, AccountInsertRequest>().ReverseMap();
            CreateMap<Account, AccountUpdateRequest>().ReverseMap();
            CreateMap<Account, AccountSearchRequest>().ReverseMap();


        }
    }
}
