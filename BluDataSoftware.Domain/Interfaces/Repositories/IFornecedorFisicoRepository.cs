using BluDataSoftware.Domain.Entities;
using System.Collections.Generic;

namespace BluDataSoftware.Domain.Interfaces.Repositories
{
    public interface IFornecedorFisicoRepository : IRepositoryBase<FornecedorFisico>
    {
        void AddEmpresa(FornecedorFisico obj); 
      
    }
}
