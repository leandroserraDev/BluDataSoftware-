using BluDataSoftware.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BluDataSoftware.InfraStructure.Data.Map
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("Empresa");
            HasKey(x => x.EmpresaId);
            
            Property(x => x.NomeFantasia)
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Uf)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
