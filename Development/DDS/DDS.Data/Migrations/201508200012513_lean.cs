namespace DDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lean : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condimentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Dificultad = c.Int(),
                        Temporada = c.Int(nullable: false),
                        Calorias = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Porcion = c.Int(),
                        CaloriasPorcion = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pasos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Imagen = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Perfil_Nombre = c.String(maxLength: 50),
                        Perfil_Sexo = c.Int(),
                        Perfil_FechaNacimiento = c.DateTime(),
                        Perfil_Altura = c.Single(),
                        Perfil_Complexion = c.Int(),
                        Perfil_Dieta = c.Int(),
                        Perfil_PreferenciaAlimenticia = c.Int(),
                        Perfil_Rutina = c.Int(),
                        Password = c.String(nullable: false, maxLength: 50),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaUltimaModificacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecetasCondimentos",
                c => new
                    {
                        RecetaId = c.Int(nullable: false),
                        CondimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecetaId, t.CondimentoId })
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: true)
                .ForeignKey("dbo.Condimentos", t => t.CondimentoId, cascadeDelete: true)
                .Index(t => t.RecetaId)
                .Index(t => t.CondimentoId);
            
            CreateTable(
                "dbo.RecetasIngredientes",
                c => new
                    {
                        RecetaId = c.Int(nullable: false),
                        IngredienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecetaId, t.IngredienteId })
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredientes", t => t.IngredienteId, cascadeDelete: true)
                .Index(t => t.RecetaId)
                .Index(t => t.IngredienteId);
            
            CreateTable(
                "dbo.RecetasPasos",
                c => new
                    {
                        RecetaId = c.Int(nullable: false),
                        PasoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecetaId, t.PasoId })
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: true)
                .ForeignKey("dbo.Pasos", t => t.PasoId, cascadeDelete: true)
                .Index(t => t.RecetaId)
                .Index(t => t.PasoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecetasPasos", "PasoId", "dbo.Pasos");
            DropForeignKey("dbo.RecetasPasos", "RecetaId", "dbo.Recetas");
            DropForeignKey("dbo.RecetasIngredientes", "IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.RecetasIngredientes", "RecetaId", "dbo.Recetas");
            DropForeignKey("dbo.RecetasCondimentos", "CondimentoId", "dbo.Condimentos");
            DropForeignKey("dbo.RecetasCondimentos", "RecetaId", "dbo.Recetas");
            DropIndex("dbo.RecetasPasos", new[] { "PasoId" });
            DropIndex("dbo.RecetasPasos", new[] { "RecetaId" });
            DropIndex("dbo.RecetasIngredientes", new[] { "IngredienteId" });
            DropIndex("dbo.RecetasIngredientes", new[] { "RecetaId" });
            DropIndex("dbo.RecetasCondimentos", new[] { "CondimentoId" });
            DropIndex("dbo.RecetasCondimentos", new[] { "RecetaId" });
            DropTable("dbo.RecetasPasos");
            DropTable("dbo.RecetasIngredientes");
            DropTable("dbo.RecetasCondimentos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pasos");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.Recetas");
            DropTable("dbo.Condimentos");
        }
    }
}
