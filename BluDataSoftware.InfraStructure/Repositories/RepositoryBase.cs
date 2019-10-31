using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.InfraStructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluDataSoftware.InfraStructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly BluDataContext _repositoryBase;

        public RepositoryBase(BluDataContext empresaContext)
        {
            _repositoryBase = empresaContext;
        }

        public virtual void Add(TEntity obj)
        {
            _repositoryBase.Set<TEntity>().Add(obj);
        }

        public virtual void Delete(int id)
        {
            var removeId = _repositoryBase.Set<TEntity>().Find(id);
            _repositoryBase.Set<TEntity>().Remove(removeId);
        }

        public virtual void Edit(TEntity obj)
        {
            _repositoryBase.Entry(obj).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.Set<TEntity>().ToList();
        }

   

        public virtual TEntity GetById(int id)
        {
            return _repositoryBase.Set<TEntity>().Find(id);
        }

        public virtual void SaveChanges()
        {
            _repositoryBase.SaveChanges();
        }
    }
}

