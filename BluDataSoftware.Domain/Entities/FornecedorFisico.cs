
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluDataSoftware.Domain.Entities
{
    public class FornecedorFisico 
    {
        
        public FornecedorFisico(string nome, 
            string cpf, 
            string rg, 
            string telefone, 
            DateTime dataNascimento,
            DateTime dataCadastro)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCadastro = DateTime.Now;
            EmpresaId = null;
        }

        protected FornecedorFisico()
        {

        }
        public int FornecedorId { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }     
        public string Rg  { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get;  set; }
        public int? EmpresaId { get; private set; }
        public virtual Empresa Empresa { get; private set; }

        public void AddEmpresaId(int? id)
        {
            EmpresaId = null;
              EmpresaId = id;
        }
    }
}
