using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public interface IService<TModel, TSearch>
    {

        TModel GetById(int id);
        List<TModel> GetAll(TSearch search);

    }
}
