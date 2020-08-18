namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        EstadoProyecto = c.Int(nullable: false),
                        Cliente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ID)
                .Index(t => t.IdCliente)
                .Index(t => t.Cliente_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectos", "Cliente_ID", "dbo.Clientes");
            DropForeignKey("dbo.Proyectos", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Proyectos", new[] { "Cliente_ID" });
            DropIndex("dbo.Proyectos", new[] { "IdCliente" });
            DropTable("dbo.Proyectos");
            DropTable("dbo.Clientes");
        }
    }
}
