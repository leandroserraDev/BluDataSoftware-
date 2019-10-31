namespace BluDataSoftware.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresa", "Cnpj", c => c.Int(nullable: false));
            AlterColumn("dbo.FornecedorFisico", "DataCadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FornecedorFisico", "DataCadastro", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Empresa", "Cnpj");
        }
    }
}
