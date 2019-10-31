using BluDataSoftware.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BluDataSoftware.InfraStructure.Data.Map
{
    public class FornecedorJuridicoMap : EntityTypeConfiguration<FornecedorJuridico>
    {
        public FornecedorJuridicoMap()
        {
            ToTable("FornecedorJuridico");
            HasKey(x => x.FornecedorId);

            Property(x => x.Nome)
                .HasMaxLength(120)
                .IsRequired();

            Property(x => x.Telefone)
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.Cnpj)
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.EmpresaId)
                .IsOptional();

            Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            HasOptional(x => x.Empresa).WithMany();

        }
    }
}
