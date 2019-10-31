using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BluDataSoftware.Domain.Services
{
    public class ServiceFornecedorFisico : ServiceBase<FornecedorFisico>, IServiceFornecedorFisico
    {
        private readonly IFornecedorFisicoRepository _serviceFornecedor;
        public ServiceFornecedorFisico(IFornecedorFisicoRepository fornecedorService)
            : base(fornecedorService)
        {
            _serviceFornecedor = fornecedorService;
        }

        public void AddEmpresa(FornecedorFisico obj)
        {
            _serviceFornecedor.AddEmpresa(obj);
        }
    }
}
