namespace BluDataSoftware.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresa", "Cnpj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresa", "Cnpj", c => c.Int(nullable: false));
        }
    }
}
