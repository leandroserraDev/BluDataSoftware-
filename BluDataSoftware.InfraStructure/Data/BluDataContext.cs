using BluDataSoftware.Domain.Entities;
using BluDataSoftware.InfraStructure.Data.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BluDataSoftware.InfraStructure.Data
{
    public class BluDataContext : DbContext
    {
        public BluDataContext() 
            :base("Connections")
        { }

        public DbSet<Empresa> Empresas{ get; set; }
        public virtual DbSet<FornecedorFisico> FornecedoresFisicos{ get;  set; }
        public DbSet<FornecedorJuridico> FornecedoresJuridicos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new FornecedorFisicoMap());
            modelBuilder.Configurations.Add(new FornecedorJuridicoMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

      
    }
}

