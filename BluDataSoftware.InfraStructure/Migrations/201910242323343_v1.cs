namespace BluDataSoftware.InfraStructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        NomeFantasia = c.String(nullable: false, maxLength: 30),
                        Uf = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.EmpresaId);
            
            CreateTable(
                "dbo.FornecedorFisico",
                c => new
                    {
                        FornecedorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 120),
                        Cpf = c.String(nullable: false, maxLength: 15),
                        Rg = c.String(nullable: false, maxLength: 15),
                        DataNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        DataCadastro = c.DateTime(nullable: false),
                        EmpresaId = c.Int(),
                    })
                .PrimaryKey(t => t.FornecedorId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.FornecedorJuridico",
                c => new
                    {
                        FornecedorId = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 15),
                        Nome = c.String(nullable: false, maxLength: 120),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        DataCadastro = c.DateTime(nullable: false),
                        EmpresaId = c.Int(),
                    })
                .PrimaryKey(t => t.FornecedorId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.EmpresaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FornecedorJuridico", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.FornecedorFisico", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.FornecedorJuridico", new[] { "EmpresaId" });
            DropIndex("dbo.FornecedorFisico", new[] { "EmpresaId" });
            DropTable("dbo.FornecedorJuridico");
            DropTable("dbo.FornecedorFisico");
            DropTable("dbo.Empresa");
        }
    }
}
