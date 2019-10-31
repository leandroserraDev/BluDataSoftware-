using AutoMapper;
using BluDataSoftware.Domain.Entities;
using BluDataSoftware.UII.Models.Empresa;
using BluDataSoftware.UII.Models.FornecedorFisico;
using BluDataSoftware.UII.Models.FornecedorJuridico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluDataSoftware.UII.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EmpresaIndexViewModel, Empresa>();
            CreateMap<FornecedorFisicoViewModel, FornecedorFisico>();
            CreateMap<FornecedorJuridicoViewModel, FornecedorJuridico>();
        }
    }
}