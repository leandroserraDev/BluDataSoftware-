using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluDataSoftware.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _serviceBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _serviceBase = repositoryBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Delete(int id)
        {
            _serviceBase.Delete(id);
        }

        public void Edit(TEntity obj)
        {
            _serviceBase.Edit(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

   

        public TEntity GetById(int id)
        {
          return _serviceBase.GetById(id);
        }

        public void SaveChanges()
        {
            _serviceBase.SaveChanges();
        }
    }
}
