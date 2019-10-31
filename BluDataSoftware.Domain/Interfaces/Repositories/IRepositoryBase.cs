using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluDataSoftware.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Delete(int id);
        void Edit(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void SaveChanges();
  
    }
}
