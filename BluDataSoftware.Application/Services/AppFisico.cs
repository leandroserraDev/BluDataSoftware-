using BluDataSoftware.Application.Interfaces;
using BluDataSoftware.Application.Services;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BluData.Application.Services
{
    public class AppFisico : AppService<FornecedorFisico>, IAppFisico
    {
        private readonly IServiceFornecedorFisico _fisicoService;
        public AppFisico(IServiceFornecedorFisico fisicoService)
            :base(fisicoService)
        {
            _fisicoService = fisicoService;
        }

        public void AddEmpresa(FornecedorFisico obj)
        {
            _fisicoService.AddEmpresa(obj);
        }
    }
}
