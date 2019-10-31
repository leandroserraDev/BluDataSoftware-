using BluDataSoftware.Application.Interfaces;
using BluDataSoftware.Domain.Entities;

namespace BluDataSoftware.Application.Interfaces
{
    public interface IAppFisico : IAppService<FornecedorFisico>
    {
        void AddEmpresa(FornecedorFisico obj);
    }
}
