using BluDataSoftware.Application.Interfaces;
using BluDataSoftware.Application.Services;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Services;

namespace BluData.Application.Services
{
    public class AppJuridico : AppService<FornecedorJuridico>, IAppJuridico
    {
        private readonly IServiceFornecedorJuridico _serviceJuridico;
        public AppJuridico(IServiceFornecedorJuridico serviceJuridico)
            :base(serviceJuridico)
    
        {
            _serviceJuridico = serviceJuridico;
        }

      
    }
}
