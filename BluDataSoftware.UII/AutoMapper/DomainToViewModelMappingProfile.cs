using AutoMapper;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.UII.Models.Empresa;
using BluDataSoftware.UII.Models.FornecedorFisico;
using BluDataSoftware.UII.Models.FornecedorJuridico;

namespace BluDataSoftware.UII.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<EmpresaIndexViewModel, Empresa>();
            CreateMap<FornecedorFisicoViewModel, FornecedorFisico>();
            CreateMap<FornecedorJuridicoViewModel, FornecedorJuridico>();
        }
    }
}