using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace BluDataSoftware.Domain.Interfaces.Services
{
    public interface IServiceFornecedorFisico : IServiceBase<FornecedorFisico>
    {
        void AddEmpresa(FornecedorFisico obj);
    }
}
