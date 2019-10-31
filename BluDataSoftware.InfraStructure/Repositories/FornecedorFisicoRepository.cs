using BluDataSoftware.Domain.Entities;
using BluDataSoftware.Domain.Interfaces.Repositories;
using BluDataSoftware.InfraStructure.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BluDataSoftware.InfraStructure.Repositories
{
    public class FornecedorFisicoRepository :   RepositoryBase<FornecedorFisico>, IFornecedorFisicoRepository
    {
        private readonly BluDataContext _fisicoContext;
        public FornecedorFisicoRepository(BluDataContext context)
            :base(context)
        {
            _fisicoContext = context;
        }

        public override void Edit(FornecedorFisico obj)
        {

            _fisicoContext.Entry(obj).State = EntityState.Modified;
            _fisicoContext.Entry(obj).Property(x => x.EmpresaId).IsModified = false;
        }

        public void AddEmpresa(FornecedorFisico obj)
        {
            var fornecedorBanco = _fisicoContext.FornecedoresFisicos.Where(x => x.FornecedorId == obj.FornecedorId).FirstOrDefault();
            fornecedorBanco = null;
            fornecedorBanco.AddEmpresaId(obj.EmpresaId);
        }
    }
}
