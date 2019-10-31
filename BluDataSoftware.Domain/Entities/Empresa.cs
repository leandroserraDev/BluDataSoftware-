using System.Collections.Generic;

namespace BluDataSoftware.Domain.Entities
{
    public class Empresa
    {

        public Empresa(string nomeFantasia, string uf, string cnpj)
        {
            NomeFantasia = nomeFantasia;
            Uf = uf;
            Cnpj = cnpj;
        }
        protected Empresa()
        {

        }
        public int EmpresaId { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string Uf { get; private set; }

        public virtual IEnumerable<FornecedorFisico> FornecedoresFisicos { get; private set; }
        public virtual IEnumerable<FornecedorJuridico>FornecedoresJuridicos { get; private set; }

    }
}