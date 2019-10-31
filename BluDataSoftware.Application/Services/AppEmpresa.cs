using BluDataSoftware.Application.Interfaces;
using BluDataSoftware.Application.Services;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Services;

namespace BluData.Application.Services
{
    public class AppEmpresa :  AppService<Empresa>, IAppEmpresa
    {
        private readonly IServiceEmpresa _empresaService;
        public AppEmpresa(IServiceEmpresa serviceEmpresa)
            :base(serviceEmpresa)
  
        {
            _empresaService = serviceEmpresa;
        }

       
    }
}
