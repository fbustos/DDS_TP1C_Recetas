namespace DDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Perfil_FechaNacimiento", c => c.DateTime());
            AddColumn("dbo.Usuarios", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "FechaUltimaModificacion", c => c.DateTime());
            DropColumn("dbo.Usuarios", "Perfil_Edad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Perfil_Edad", c => c.Int());
            DropColumn("dbo.Usuarios", "FechaUltimaModificacion");
            DropColumn("dbo.Usuarios", "FechaCreacion");
            DropColumn("dbo.Usuarios", "Perfil_FechaNacimiento");
        }
    }
}
