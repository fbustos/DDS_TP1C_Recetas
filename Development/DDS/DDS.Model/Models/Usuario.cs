using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DDS.Model.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.Perfil = new Perfil();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public Perfil Perfil { get; set; }

        public string Password { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaUltimaModificacion { get; set; }

        public virtual IList<Grupo> Grupos { get; set; }

        public virtual IList<Receta> MisRecetas { get; set; } 

        public void SetPassword(string password)
        {
            this.Password = this.Hash(password);
        }

        public bool CheckPassword(string password)
        {
            return string.Equals(this.Password, this.Hash(password));
        }

        public bool ActualizarPerfil()
        {
            return !FechaUltimaModificacion.HasValue || FechaUltimaModificacion.Value <= DateTime.Now.AddYears(-1);
        }

        private string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
