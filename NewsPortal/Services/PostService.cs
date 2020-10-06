using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Database;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NewsPortal.Services
{
    public class PostService : BaseCRUDService<MPost, PostSearchRequest, PostUpdateRequest, PostInsertRequest, Database.Post>
    {
        public PostService(SoftraySolutionsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<MPost> GetAll(PostSearchRequest search = null)
        {
            var query = _context.Set<Post>().AsQueryable();

            if (search.Username != null)
                query = query.Where(i => i.Account.Username == search.Username);

            var list = query.Include(a => a.Account).ToList();

            return _mapper.Map<List<MPost>>(list);
        }
        public override MPost GetById(int id)
        {
            var entity = _context.Set<Post>().Include(a=>a.Account).Where(i=>i.PostId == id).FirstOrDefault();
            return _mapper.Map<MPost>(entity);
        }
    }
}
