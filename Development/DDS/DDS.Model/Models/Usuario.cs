using System;
using System.Text;

namespace DDS.Model.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public Perfil Perfil { get; set; }

        public string Password { get; set; }

        public void SetPassword(string password)
        {
            this.Password = this.Hash(password);
        }

        public bool CheckPassword(string password)
        {
            return string.Equals(this.Password, this.Hash(password));
        }

        private string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
