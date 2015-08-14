namespace DDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nueva : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Condimentoes", newName: "Condimentos");
            RenameTable(name: "dbo.Pasoes", newName: "Pasos");
            RenameTable(name: "dbo.CondimentoRecetas", newName: "RecetasCondimentos");
            RenameTable(name: "dbo.IngredienteRecetas", newName: "RecetasIngredientes");
            RenameTable(name: "dbo.PasoRecetas", newName: "RecetasPasos");
            RenameColumn(table: "dbo.RecetasCondimentos", name: "Condimento_Id", newName: "CondimentoId");
            RenameColumn(table: "dbo.RecetasCondimentos", name: "Receta_Id", newName: "RecetaId");
            RenameColumn(table: "dbo.RecetasIngredientes", name: "Ingrediente_Id", newName: "IngredienteId");
            RenameColumn(table: "dbo.RecetasIngredientes", name: "Receta_Id", newName: "RecetaId");
            RenameColumn(table: "dbo.RecetasPasos", name: "Paso_Id", newName: "PasoId");
            RenameColumn(table: "dbo.RecetasPasos", name: "Receta_Id", newName: "RecetaId");
            RenameIndex(table: "dbo.RecetasCondimentos", name: "IX_Receta_Id", newName: "IX_RecetaId");
            RenameIndex(table: "dbo.RecetasCondimentos", name: "IX_Condimento_Id", newName: "IX_CondimentoId");
            RenameIndex(table: "dbo.RecetasIngredientes", name: "IX_Receta_Id", newName: "IX_RecetaId");
            RenameIndex(table: "dbo.RecetasIngredientes", name: "IX_Ingrediente_Id", newName: "IX_IngredienteId");
            RenameIndex(table: "dbo.RecetasPasos", name: "IX_Receta_Id", newName: "IX_RecetaId");
            RenameIndex(table: "dbo.RecetasPasos", name: "IX_Paso_Id", newName: "IX_PasoId");
            DropPrimaryKey("dbo.RecetasCondimentos");
            DropPrimaryKey("dbo.RecetasIngredientes");
            DropPrimaryKey("dbo.RecetasPasos");
            AddColumn("dbo.Recetas", "Nombre", c => c.String());
            AddColumn("dbo.Recetas", "Dificultad", c => c.Int());
            AddColumn("dbo.Recetas", "Temporada", c => c.Int(nullable: false));
            AddColumn("dbo.Recetas", "Calorias", c => c.Double());
            AddColumn("dbo.Usuarios", "Perfil_PreferenciaAlimenticia", c => c.Int());
            AlterColumn("dbo.Condimentos", "Tipo", c => c.Int());
            AlterColumn("dbo.Ingredientes", "Porcion", c => c.Int());
            AlterColumn("dbo.Ingredientes", "CaloriasPorcion", c => c.Double());
            AddPrimaryKey("dbo.RecetasCondimentos", new[] { "RecetaId", "CondimentoId" });
            AddPrimaryKey("dbo.RecetasIngredientes", new[] { "RecetaId", "IngredienteId" });
            AddPrimaryKey("dbo.RecetasPasos", new[] { "RecetaId", "PasoId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RecetasPasos");
            DropPrimaryKey("dbo.RecetasIngredientes");
            DropPrimaryKey("dbo.RecetasCondimentos");
            AlterColumn("dbo.Ingredientes", "CaloriasPorcion", c => c.Double(nullable: false));
            AlterColumn("dbo.Ingredientes", "Porcion", c => c.Int(nullable: false));
            AlterColumn("dbo.Condimentos", "Tipo", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Perfil_PreferenciaAlimenticia");
            DropColumn("dbo.Recetas", "Calorias");
            DropColumn("dbo.Recetas", "Temporada");
            DropColumn("dbo.Recetas", "Dificultad");
            DropColumn("dbo.Recetas", "Nombre");
            AddPrimaryKey("dbo.RecetasPasos", new[] { "Paso_Id", "Receta_Id" });
            AddPrimaryKey("dbo.RecetasIngredientes", new[] { "Ingrediente_Id", "Receta_Id" });
            AddPrimaryKey("dbo.RecetasCondimentos", new[] { "Condimento_Id", "Receta_Id" });
            RenameIndex(table: "dbo.RecetasPasos", name: "IX_PasoId", newName: "IX_Paso_Id");
            RenameIndex(table: "dbo.RecetasPasos", name: "IX_RecetaId", newName: "IX_Receta_Id");
            RenameIndex(table: "dbo.RecetasIngredientes", name: "IX_IngredienteId", newName: "IX_Ingrediente_Id");
            RenameIndex(table: "dbo.RecetasIngredientes", name: "IX_RecetaId", newName: "IX_Receta_Id");
            RenameIndex(table: "dbo.RecetasCondimentos", name: "IX_CondimentoId", newName: "IX_Condimento_Id");
            RenameIndex(table: "dbo.RecetasCondimentos", name: "IX_RecetaId", newName: "IX_Receta_Id");
            RenameColumn(table: "dbo.RecetasPasos", name: "RecetaId", newName: "Receta_Id");
            RenameColumn(table: "dbo.RecetasPasos", name: "PasoId", newName: "Paso_Id");
            RenameColumn(table: "dbo.RecetasIngredientes", name: "RecetaId", newName: "Receta_Id");
            RenameColumn(table: "dbo.RecetasIngredientes", name: "IngredienteId", newName: "Ingrediente_Id");
            RenameColumn(table: "dbo.RecetasCondimentos", name: "RecetaId", newName: "Receta_Id");
            RenameColumn(table: "dbo.RecetasCondimentos", name: "CondimentoId", newName: "Condimento_Id");
            RenameTable(name: "dbo.RecetasPasos", newName: "PasoRecetas");
            RenameTable(name: "dbo.RecetasIngredientes", newName: "IngredienteRecetas");
            RenameTable(name: "dbo.RecetasCondimentos", newName: "CondimentoRecetas");
            RenameTable(name: "dbo.Pasos", newName: "Pasoes");
            RenameTable(name: "dbo.Condimentos", newName: "Condimentoes");
        }
    }
}
