namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                        Apellido = c.String(maxLength: 50),
                        DniCuit = c.Long(nullable: false),
                        RazonSocial = c.String(maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        TelefonoContacto = c.Long(),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.DniCuit, unique: true);
            
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
                .Index(t => new { t.ClienteID, t.Nombre }, unique: true)
                .Index(t => t.ProyectoEstadoID);
            
            CreateTable(
                "dbo.ProyectoEstados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Descripcion, unique: true);
            
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
                .Index(t => new { t.EmpleadoID, t.PerfilID }, unique: true);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Dni = c.Long(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        Clave = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Dni, unique: true);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        ValorHorario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Descripcion, unique: true);
            
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
                        EsOB = c.Boolean(nullable: false),
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

            /* Scripts */
            /* Perfiles */
            Sql("INSERT INTO [dbo].[Perfiles] ([Descripcion], [ValorHorario]) VALUES (N'Analista', CAST(100.00 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[Perfiles] ([Descripcion], [ValorHorario]) VALUES (N'Desarrollador', CAST(150.00 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[Perfiles] ([Descripcion], [ValorHorario]) VALUES (N'Tester', CAST(200.00 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[Perfiles] ([Descripcion], [ValorHorario]) VALUES (N'Implementador', CAST(250.00 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[Perfiles] ([Descripcion], [ValorHorario]) VALUES (N'Capacitador', CAST(300.00 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[Perfiles] ([Descripcion], [ValorHorario]) VALUES (N'Supervisor', CAST(350.00 AS Decimal(18, 2)))");

            /* Aumento por Antiguedad */
            Sql("INSERT INTO [dbo].[EscalaAumentoxAntiguedades] ([Limiteanios], [PorcentajeAumento]) VALUES (1, CAST(0.50 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxAntiguedades] ([Limiteanios], [PorcentajeAumento]) VALUES (2, CAST(0.70 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxAntiguedades] ([Limiteanios], [PorcentajeAumento]) VALUES (3, CAST(0.80 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxAntiguedades] ([Limiteanios], [PorcentajeAumento]) VALUES (4, CAST(0.90 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxAntiguedades] ([Limiteanios], [PorcentajeAumento]) VALUES (5, CAST(1.00 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxAntiguedades] ([Limiteanios], [PorcentajeAumento]) VALUES (10, CAST(2.00 AS Decimal(18, 2)))");

            /* Aumento por Cantidad de horas trabajadas */
            Sql("INSERT INTO [dbo].[EscalaAumentoxHoras] ([LimiteHoras], [PorcentajeAumento]) VALUES (CAST(100.00 AS Decimal(18, 2)), CAST(0.50 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxHoras] ([LimiteHoras], [PorcentajeAumento]) VALUES (CAST(120.00 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxHoras] ([LimiteHoras], [PorcentajeAumento]) VALUES (CAST(140.00 AS Decimal(18, 2)), CAST(0.70 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxHoras] ([LimiteHoras], [PorcentajeAumento]) VALUES (CAST(160.00 AS Decimal(18, 2)), CAST(0.80 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxHoras] ([LimiteHoras], [PorcentajeAumento]) VALUES (CAST(180.00 AS Decimal(18, 2)), CAST(0.90 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxHoras] ([LimiteHoras], [PorcentajeAumento]) VALUES (CAST(200.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)))");
          
            /* Aumento por cantidad de Perfiles */
            Sql("INSERT INTO [dbo].[EscalaAumentoxPerfiles] ([LimitecantPerfiles], [PorcentajeAumento]) VALUES (2, CAST(0.20 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxPerfiles] ([LimitecantPerfiles], [PorcentajeAumento]) VALUES (3, CAST(0.50 AS Decimal(18, 2)))");
            Sql("INSERT INTO [dbo].[EscalaAumentoxPerfiles] ([LimitecantPerfiles], [PorcentajeAumento]) VALUES (4, CAST(0.80 AS Decimal(18, 2)))");

            /* Estados de Horas Trabajadas */
            Sql("SET IDENTITY_INSERT [dbo].[HorasTrabajadasEstados] ON");
            Sql("INSERT INTO [dbo].[HorasTrabajadasEstados] ([ID], [Descripcion]) VALUES (1, N'Pagada')");
            Sql("INSERT INTO [dbo].[HorasTrabajadasEstados] ([ID], [Descripcion]) VALUES (2, N'Adeudada')");
            Sql("SET IDENTITY_INSERT [dbo].[HorasTrabajadasEstados] OFF");
            
            /* Estados de Proyectos */
            Sql("SET IDENTITY_INSERT [dbo].[ProyectoEstados] ON");
            Sql("INSERT INTO [dbo].[ProyectoEstados] ([ID], [Descripcion]) VALUES (1, N'Vigente')");
            Sql("INSERT INTO [dbo].[ProyectoEstados] ([ID], [Descripcion]) VALUES (2, N'Pausado')");
            Sql("INSERT INTO [dbo].[ProyectoEstados] ([ID], [Descripcion]) VALUES (3, N'Cancelado')");
            Sql("INSERT INTO [dbo].[ProyectoEstados] ([ID], [Descripcion]) VALUES (4, N'Finalizado')");
            Sql("SET IDENTITY_INSERT [dbo].[ProyectoEstados] OFF");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Tareas", "ProyectoID", "dbo.Proyectos");
            DropForeignKey("dbo.HorasTrabajadas", "TareaID", "dbo.Tareas");
            DropForeignKey("dbo.HorasTrabajadas", "HorasTrabajadasEstadoID", "dbo.HorasTrabajadasEstados");
            DropForeignKey("dbo.Tareas", "EmpleadoPerfilID", "dbo.EmpleadosPerfiles");
            DropForeignKey("dbo.EmpleadosPerfiles", "PerfilID", "dbo.Perfiles");
            DropForeignKey("dbo.EmpleadosPerfiles", "EmpleadoID", "dbo.Empleados");
            DropForeignKey("dbo.Proyectos", "ProyectoEstadoID", "dbo.ProyectoEstados");
            DropForeignKey("dbo.Proyectos", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.HorasTrabajadas", new[] { "HorasTrabajadasEstadoID" });
            DropIndex("dbo.HorasTrabajadas", new[] { "TareaID" });
            DropIndex("dbo.Perfiles", new[] { "Descripcion" });
            DropIndex("dbo.Empleados", new[] { "Dni" });
            DropIndex("dbo.EmpleadosPerfiles", new[] { "EmpleadoID", "PerfilID" });
            DropIndex("dbo.Tareas", new[] { "EmpleadoPerfilID" });
            DropIndex("dbo.Tareas", new[] { "ProyectoID" });
            DropIndex("dbo.ProyectoEstados", new[] { "Descripcion" });
            DropIndex("dbo.Proyectos", new[] { "ProyectoEstadoID" });
            DropIndex("dbo.Proyectos", new[] { "ClienteID", "Nombre" });
            DropIndex("dbo.Clientes", new[] { "DniCuit" });
            DropTable("dbo.EscalaHorasOB");
            DropTable("dbo.EscalaAumentoxPerfiles");
            DropTable("dbo.EscalaAumentoxHoras");
            DropTable("dbo.EscalaAumentoxAntiguedades");
            DropTable("dbo.HorasTrabajadasEstados");
            DropTable("dbo.HorasTrabajadas");
            DropTable("dbo.Perfiles");
            DropTable("dbo.Empleados");
            DropTable("dbo.EmpleadosPerfiles");
            DropTable("dbo.Tareas");
            DropTable("dbo.ProyectoEstados");
            DropTable("dbo.Proyectos");
            DropTable("dbo.Clientes");
        }
    }
}
