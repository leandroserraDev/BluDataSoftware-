using BluDataSoftware.UII.Models.Empresa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BluDataSoftware.UII.Models.FornecedorFisico
{
    public class FornecedorFisicoViewModel
    {

        [Key]
        public int FornecedorId { get;  set; }

        [Display(Name="Nome")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [MaxLength(30, ErrorMessage ="Máximo de 20 caracteres")]
        [MinLength(3, ErrorMessage ="Mínimo de 3 caracteres")]
        public string Nome { get;  set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [MaxLength(12, ErrorMessage = "Máximo de 12 caracteres")]
        [MinLength(12, ErrorMessage = "Mínimo de 12 caracteres")]
        public string Cpf { get;  set; }

        [Display(Name = "Rg")]
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [MaxLength(12, ErrorMessage = "Máximo de 12 caracteres")]
        [MinLength(12, ErrorMessage = "Mínimo de 12 caracteres")]
        public string Rg { get;  set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get;  set; }

        [Required]
        public string Telefone { get;  set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [Display(Name="Id da empresa")]
        public int? EmpresaId { get;  set; }
        public virtual EmpresaIndexViewModel Empresa { get; set; }
    }
}