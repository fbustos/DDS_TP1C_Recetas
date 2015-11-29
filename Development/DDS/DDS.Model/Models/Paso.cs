namespace DDS.Model.Models
{
    public class Paso
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public string Descripcion { get; set; }

        public string ImagenPath { get; set; }

        public virtual Receta Receta { get; set; }
    }
}
