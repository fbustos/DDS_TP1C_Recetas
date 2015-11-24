using System.Web;

namespace DDS.Models.ViewModels
{
    public class PasoViewModel
    {
        public int Id { get; set; }

        public int RecetaId { get; set; }

        public int Numero { get; set; }

        public string Descripcion { get; set; }

        public HttpPostedFileBase Imagen { get; set; }

        public string ImagenPath { get; set; }

        public string Code
        {
            get { return "REC_" + this.RecetaId; }
        }

        public string NombreImagen
        {
            get { return "Paso_" + this.Numero; }
        }
    }
}