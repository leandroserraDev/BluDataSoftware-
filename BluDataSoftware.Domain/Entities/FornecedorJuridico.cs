
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluDataSoftware.Domain.Entities
{
    public class FornecedorJuridico 
    {
        public FornecedorJuridico(string nome,
              string cnpj,
              string telefone)

        {
            this.Nome = nome;
            this.Cnpj = cnpj;
            this.Telefone = telefone;
            DataCadastro = DateTime.Now;
        }
        protected FornecedorJuridico()
        {

        }
        public int FornecedorId { get; set; }
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public int? EmpresaId { get; private set; }
        public virtual Empresa Empresa { get; private set; }

    }
}
