using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.InfraStructure.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BluDataSoftware.InfraStructure.Repositories
{
    public class FornecedorJuridicoRepository : RepositoryBase<FornecedorJuridico>, IFornecedorJuridicoRepository
    {
        private readonly BluDataContext _juridicoContext;
        public FornecedorJuridicoRepository(BluDataContext context)
            : base(context)
        
        {
            _juridicoContext = context;
        }

      
    }
}
