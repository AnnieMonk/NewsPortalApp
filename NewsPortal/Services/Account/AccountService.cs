using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Database;
using NewsPortal.Filters;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class AccountService : IAccount
    {
        private readonly IHttpContextAccessor accessor;
        protected SoftraySolutionsContext _context;
        protected IMapper _mapper;
        public AccountService(SoftraySolutionsContext context, IMapper mapper, IHttpContextAccessor accessor)
        {
            _context = context;
            _mapper = mapper;
            this.accessor = accessor;
        }
    
        public MAccount GetLoggedUser()
        {
            var listOfClaims = accessor?.HttpContext?.User.Claims.ToList();
            if(listOfClaims.Count > 0) { 
            var query = _context.Account.Where(i => i.Username == listOfClaims[0].Value).FirstOrDefault() ;
            return _mapper.Map<MAccount>(query);
            }

            return null;
        }

        public List<MAccount> GetAll(AccountSearchRequest search)
        {
            var query = _context.Set<Account>().AsQueryable();
            query = query.Include(u => u.User);
            if (search.Username != null)
            {
                query = query.Where(u => u.Username == search.Username);
            }

            var list = query.ToList();
            return _mapper.Map<List<MAccount>>(list);
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public  MAccount Insert(AccountInsertRequest request)
        {
            //first check if username is existant
            var list = _context.Account.ToList();

            if (list.Select(i => i.Username).Contains(request.Username))
            {
                throw new UserException("Username is taken!");
            }
         
            var entity = _mapper.Map<Account>(request);
            _context.Add(entity);

            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Passwords must match!");
            }

            entity.PassHsalt = GenerateSalt();
            entity.PassHash = GenerateHash(entity.PassHsalt, request.Password);

            _context.SaveChanges();

            foreach (var role in request.Roles)
            {
                Database.UserRole userRoles = new Database.UserRole();
                userRoles.UserId = entity.UserId;
                userRoles.RoleId = role;
                userRoles.DateCreated = DateTime.Now;
                _context.UserRole.Add(userRoles);
            }
            _context.SaveChanges();

            return _mapper.Map<MAccount>(entity);
        }

        public MAccount Login(AccountSearchRequest search)
        {
            var user = _context.Account.Include(u=>u.User.UserRole).FirstOrDefault(x => x.Username == search.Username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PassHsalt, search.Password);

                if (newHash == user.PassHash)
                {
                    return _mapper.Map<MAccount>(user);
                }
            }
            return null;
        }

        public MAccount GetById(int id)
        {
            var entity = _context.Account.Find(id);

            return _mapper.Map<MAccount>(entity);
        }
    }
}
