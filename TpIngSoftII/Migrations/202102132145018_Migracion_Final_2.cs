namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_Final_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Perfiles", "PerfilTipoID", "dbo.PerfilTipos");
            DropIndex("dbo.Clientes", new[] { "Dni" });
            DropIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" });
            DropIndex("dbo.EmpleadosPerfiles", new[] { "EmpleadoID", "PerfilID" });
            DropIndex("dbo.Perfiles", new[] { "PerfilTipoID" });
            AddColumn("dbo.Empleados", "Apellido", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Empleados", "Dni", c => c.Int(nullable: false));
            AddColumn("dbo.Perfiles", "Descripcion", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Clientes", "Dni", unique: true);
            CreateIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" }, unique: true);
            CreateIndex("dbo.ProyectoEstados", "Descripcion", unique: true);
            CreateIndex("dbo.EmpleadosPerfiles", new[] { "EmpleadoID", "PerfilID" }, unique: true);
            CreateIndex("dbo.Empleados", "Dni", unique: true);
            CreateIndex("dbo.Perfiles", "Descripcion", unique: true);
            DropColumn("dbo.Perfiles", "PerfilTipoID");
            DropTable("dbo.PerfilTipos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PerfilTipos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Perfiles", "PerfilTipoID", c => c.Int(nullable: false));
            DropIndex("dbo.Perfiles", new[] { "Descripcion" });
            DropIndex("dbo.Empleados", new[] { "Dni" });
            DropIndex("dbo.EmpleadosPerfiles", new[] { "EmpleadoID", "PerfilID" });
            DropIndex("dbo.ProyectoEstados", new[] { "Descripcion" });
            DropIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" });
            DropIndex("dbo.Clientes", new[] { "Dni" });
            DropColumn("dbo.Perfiles", "Descripcion");
            DropColumn("dbo.Empleados", "Dni");
            DropColumn("dbo.Empleados", "Apellido");
            CreateIndex("dbo.Perfiles", "PerfilTipoID");
            CreateIndex("dbo.EmpleadosPerfiles", new[] { "EmpleadoID", "PerfilID" });
            CreateIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" });
            CreateIndex("dbo.Clientes", "Dni");
            AddForeignKey("dbo.Perfiles", "PerfilTipoID", "dbo.PerfilTipos", "ID", cascadeDelete: true);
        }
    }
}
