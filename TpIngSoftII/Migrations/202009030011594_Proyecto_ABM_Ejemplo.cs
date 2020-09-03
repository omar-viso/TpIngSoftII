namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proyecto_ABM_Ejemplo : DbMigration
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
                        ClienteID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        EstadoProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => new { t.ClienteID, t.Nombre });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectos", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" });
            DropTable("dbo.Proyectos");
            DropTable("dbo.Clientes");
        }
    }
}
