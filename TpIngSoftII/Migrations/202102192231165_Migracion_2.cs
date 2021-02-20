namespace TpIngSoftII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Empleados", "RolID", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleados", "RolID");
            AddForeignKey("dbo.Empleados", "RolID", "dbo.Roles", "ID");

            /* Inserts */
            /* Estados de Proyectos */
            Sql("SET IDENTITY_INSERT [dbo].[Roles] ON");
            Sql("INSERT INTO [dbo].[Roles] ([ID], [Descripcion]) VALUES (1, N'ADMINISTRADOR')");
            Sql("INSERT INTO [dbo].[Roles] ([ID], [Descripcion]) VALUES (2, N'SUPERVISOR')");
            Sql("INSERT INTO [dbo].[Roles] ([ID], [Descripcion]) VALUES (3, N'EMPLEADO')");
            Sql("SET IDENTITY_INSERT [dbo].[Roles] OFF");

            /* Usuario Administrador */
            Sql("INSERT INTO [dbo].[Empleados] ([Nombre], [Apellido], [Dni], [FechaIngreso], [Usuario], [Clave], [RolID]) VALUES (N'ADMINISTRADOR', N'ADMINISTRADOR', 1, N'2021-01-01 00:00:00', N'admin', N'1234', 1)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "RolID", "dbo.Roles");
            DropIndex("dbo.Empleados", new[] { "RolID" });
            DropColumn("dbo.Empleados", "RolID");
            DropTable("dbo.Roles");
        }
    }
}
