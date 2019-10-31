namespace BluDataSoftware.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FornecedorFisico", "DataNascimento", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FornecedorFisico", "DataCadastro", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FornecedorFisico", "DataCadastro", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FornecedorFisico", "DataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
