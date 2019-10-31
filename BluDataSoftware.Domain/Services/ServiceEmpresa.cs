using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BluDataSoftware.Domain.Services
{
    public class ServiceEmpresa :  ServiceBase<Empresa>, IServiceEmpresa
    {
        private readonly IEmpresaRepository _serviceEmpresa;
        public ServiceEmpresa(IEmpresaRepository empresaRepository)
            :base(empresaRepository)
        {
            _serviceEmpresa = empresaRepository;
        }

       
    }
}
