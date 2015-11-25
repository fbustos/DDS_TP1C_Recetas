namespace DDS.Model.Models
{
    public class UsuarioReceta
    {
        public int Id { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Receta Receta { get; set; }

        public int Puntaje { get; set; } //additional info
    }
}
