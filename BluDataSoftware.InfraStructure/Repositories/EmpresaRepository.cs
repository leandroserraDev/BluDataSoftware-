
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.InfraStructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace BluDataSoftware.InfraStructure.Repositories
{
    public class EmpresaRepository : RepositoryBase<Empresa> , IEmpresaRepository
    {
        private readonly BluDataContext _empresaContext;
        public EmpresaRepository(BluDataContext context)
            :base(context)
        {
            _empresaContext = context;
        }



       
    }
}
