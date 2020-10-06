using AutoMapper;
using NewsPortal.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected readonly SoftraySolutionsContext _context;
        protected readonly IMapper _mapper;
        public BaseService(SoftraySolutionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public virtual TModel GetById(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            return _mapper.Map<TModel>(entity);
        }

        public virtual List<TModel> GetAll(TSearch search = default)
        {
            var result = _context.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(result);
        }

    
    }
}
