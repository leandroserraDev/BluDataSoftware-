using BluDataSoftware.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BluDataSoftware.InfraStructure.Data.Map
{
    public class FornecedorFisicoMap : EntityTypeConfiguration<FornecedorFisico>
    {
        public FornecedorFisicoMap()
        {
            ToTable("FornecedorFisico");
            HasKey(x => x.FornecedorId);

            Property(x => x.Nome)
                .HasMaxLength(120)
                .IsRequired();

            Property(x => x.Telefone)
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.Cpf)
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.Rg)
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(x => x.DataCadastro)
               .HasColumnType("datetime");


            HasOptional(x => x.Empresa).WithMany();



        }
    }
}
