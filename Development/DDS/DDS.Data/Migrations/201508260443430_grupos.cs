namespace DDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grupos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupos", "CreadoPor", c => c.Int(nullable: false));
            AddColumn("dbo.Grupos", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grupos", "FechaModificacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grupos", "FechaModificacion");
            DropColumn("dbo.Grupos", "FechaCreacion");
            DropColumn("dbo.Grupos", "CreadoPor");
        }
    }
}
