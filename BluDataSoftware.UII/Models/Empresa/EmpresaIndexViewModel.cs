using BluDataSoftware.UII.Models.FornecedorFisico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BluDataSoftware.UII.Models.Empresa
{
    public class EmpresaIndexViewModel
    {
        [Key]
        public int EmpresaId { get;  set; }

        [Display(Name="Nome fantasia")]
        [Required(ErrorMessage ="O nome é obrigatório")]
        [MaxLength(30, ErrorMessage ="Máximo de 30 caracteres")]
        [MinLength(4, ErrorMessage ="Mínimo de 4 caracteres")]
        public string NomeFantasia { get;  set; }

        [Required(ErrorMessage ="Cnpj é obrigatório")]
        public string Cnpj { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O estado é obrigatório")]
        public string Uf { get;  set; }

        public virtual IEnumerable<FornecedorFisicoViewModel> FornecedoresFisicos { get;  set; }
    }
}