namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proyecto_Segunda_Migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Dni = c.Int(nullable: false),
                        RazonSocial = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        TelefonoFijo = c.Int(),
                        TelefonoCelular = c.Int(),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Dni);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ProyectoEstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.ProyectoEstados", t => t.ProyectoEstadoID, cascadeDelete: true)
                .Index(t => new { t.ClienteID, t.Nombre })
                .Index(t => t.ProyectoEstadoID);
            
            CreateTable(
                "dbo.ProyectoEstados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tareas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        EmpleadoPerfilID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        HorasEstimadas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HorasOB = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmpleadosPerfiles", t => t.EmpleadoPerfilID, cascadeDelete: true)
                .ForeignKey("dbo.Proyectos", t => t.ProyectoID, cascadeDelete: true)
                .Index(t => t.ProyectoID)
                .Index(t => t.EmpleadoPerfilID);
            
            CreateTable(
                "dbo.EmpleadosPerfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmpleadoID = c.Int(nullable: false),
                        PerfilID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoID, cascadeDelete: true)
                .ForeignKey("dbo.Perfiles", t => t.PerfilID, cascadeDelete: true)
                .Index(t => new { t.EmpleadoID, t.PerfilID });
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        FechaIngreso = c.DateTime(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        Clave = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PerfilTipoID = c.Int(nullable: false),
                        ValorHorario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PerfilTipos", t => t.PerfilTipoID, cascadeDelete: true)
                .Index(t => t.PerfilTipoID);
            
            CreateTable(
                "dbo.PerfilTipos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HorasTrabajadas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProyectoID = c.Int(nullable: false),
                        TareaID = c.Int(nullable: false),
                        CantHoras = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        HorasTrabajadasEstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HorasTrabajadasEstados", t => t.HorasTrabajadasEstadoID, cascadeDelete: true)
                .ForeignKey("dbo.Tareas", t => t.TareaID, cascadeDelete: true)
                .Index(t => t.TareaID)
                .Index(t => t.HorasTrabajadasEstadoID);
            
            CreateTable(
                "dbo.HorasTrabajadasEstados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EscalaAumentoxAntiguedades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Limiteanios = c.Int(nullable: false),
                        PorcentajeAumento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EscalaAumentoxHoras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LimiteHoras = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorcentajeAumento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EscalaAumentoxPerfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LimitecantPerfiles = c.Int(nullable: false),
                        PorcentajeAumento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EscalaHorasOB",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PorcentajeAumento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);


            // INSERTS
            Sql("SET IDENTITY_INSERT [dbo].[PerfilTipos] ON");
            Sql("INSERT INTO [dbo].[PerfilTipos] ([ID], [Descripcion]) Values (1, 'Analista')");
            Sql("INSERT INTO [dbo].[PerfilTipos] ([ID], [Descripcion]) Values (2, 'Desarrollador')");
            Sql("INSERT INTO [dbo].[PerfilTipos] ([ID], [Descripcion]) Values (3, 'Tester')");
            Sql("INSERT INTO [dbo].[PerfilTipos] ([ID], [Descripcion]) Values (4, 'Implementador')");
            Sql("INSERT INTO [dbo].[PerfilTipos] ([ID], [Descripcion]) Values (5, 'Capacitador')");
            Sql("INSERT INTO [dbo].[PerfilTipos] ([ID], [Descripcion]) Values (6, 'Supervisor')");
            Sql("SET IDENTITY_INSERT [dbo].[PerfilTipos] OFF");

            Sql("SET IDENTITY_INSERT [dbo].[ProyectoEstados] ON");
            Sql("INSERT INTO [dbo].[ProyectoEstados] ([ID], [Descripcion]) Values (1, 'Vigente')");
            Sql("INSERT INTO [dbo].[ProyectoEstados] ([ID], [Descripcion]) Values (2, 'No Vigente')");
            Sql("SET IDENTITY_INSERT [dbo].[ProyectoEstados] OFF");

            Sql("SET IDENTITY_INSERT [dbo].[HorasTrabajadasEstados] ON");
            Sql("INSERT INTO [dbo].[HorasTrabajadasEstados] ([ID], [Descripcion]) Values (1, 'Pagadas')");
            Sql("INSERT INTO [dbo].[HorasTrabajadasEstados] ([ID], [Descripcion]) Values (2, 'Adeudadas')");
            Sql("SET IDENTITY_INSERT [dbo].[HorasTrabajadasEstados] OFF");





        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tareas", "ProyectoID", "dbo.Proyectos");
            DropForeignKey("dbo.HorasTrabajadas", "TareaID", "dbo.Tareas");
            DropForeignKey("dbo.HorasTrabajadas", "HorasTrabajadasEstadoID", "dbo.HorasTrabajadasEstados");
            DropForeignKey("dbo.Tareas", "EmpleadoPerfilID", "dbo.EmpleadosPerfiles");
            DropForeignKey("dbo.EmpleadosPerfiles", "PerfilID", "dbo.Perfiles");
            DropForeignKey("dbo.Perfiles", "PerfilTipoID", "dbo.PerfilTipos");
            DropForeignKey("dbo.EmpleadosPerfiles", "EmpleadoID", "dbo.Empleados");
            DropForeignKey("dbo.Proyectos", "ProyectoEstadoID", "dbo.ProyectoEstados");
            DropForeignKey("dbo.Proyectos", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.HorasTrabajadas", new[] { "HorasTrabajadasEstadoID" });
            DropIndex("dbo.HorasTrabajadas", new[] { "TareaID" });
            DropIndex("dbo.Perfiles", new[] { "PerfilTipoID" });
            DropIndex("dbo.EmpleadosPerfiles", new[] { "EmpleadoID", "PerfilID" });
            DropIndex("dbo.Tareas", new[] { "EmpleadoPerfilID" });
            DropIndex("dbo.Tareas", new[] { "ProyectoID" });
            DropIndex("dbo.Proyectos", new[] { "ProyectoEstadoID" });
            DropIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" });
            DropIndex("dbo.Clientes", new[] { "Dni" });
            DropTable("dbo.EscalaHorasOB");
            DropTable("dbo.EscalaAumentoxPerfiles");
            DropTable("dbo.EscalaAumentoxHoras");
            DropTable("dbo.EscalaAumentoxAntiguedades");
            DropTable("dbo.HorasTrabajadasEstados");
            DropTable("dbo.HorasTrabajadas");
            DropTable("dbo.PerfilTipos");
            DropTable("dbo.Perfiles");
            DropTable("dbo.Empleados");
            DropTable("dbo.EmpleadosPerfiles");
            DropTable("dbo.Tareas");
            DropTable("dbo.ProyectoEstados");
            DropTable("dbo.Proyectos");
            DropTable("dbo.Clientes");


            // DELETES
            Sql("DELETE FROM [dbo].[PerfilTipos] WHERE ID IN (1,2,3,4,5,6)");
            Sql("DELETE FROM [dbo].[ProyectoEstados] WHERE ID IN (1,2)");
            Sql("DELETE FROM [dbo].[HorasTrabajadasEstados] WHERE ID IN (1,2)");

            
        }
    }
}
