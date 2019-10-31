using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.Domain.Interfaces.Services;

namespace BluDataSoftware.Domain.Services
{
    public class ServiceFornecedorJuridico : ServiceBase<FornecedorJuridico>, IServiceFornecedorJuridico
    {
        private readonly IFornecedorJuridicoRepository _serviceFornecedorJuridico;
        public ServiceFornecedorJuridico(IFornecedorJuridicoRepository fornecedorJuridicoRepository)
            :base(fornecedorJuridicoRepository)

        {
            _serviceFornecedorJuridico = fornecedorJuridicoRepository;
        }
      
    }
}
