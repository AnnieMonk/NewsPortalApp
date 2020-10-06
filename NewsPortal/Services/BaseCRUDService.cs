using AutoMapper;
using NewsPortal.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class BaseCRUDService<TModel, TSearch, TUpdate, TInsert, TDatabase> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TUpdate, TInsert> where TDatabase : class
    {
        public BaseCRUDService(SoftraySolutionsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Delete(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
          
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);
            
            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }
    }
}
