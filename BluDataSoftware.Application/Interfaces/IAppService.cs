using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluDataSoftware.Application.Interfaces
{
   public interface IAppService<TEntity> where TEntity : class
    {

        void Add(TEntity obj);
        void Delete(int id);
        void Edit(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void SaveChanges();
    }
}
