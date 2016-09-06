using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public class Login
    {
        private Usuario usuario;
        private string hashedPassword;

        public Login(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public bool Autenticar(string hashedPassword)
        {
            return true;
        }

        public string HashPassword(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                throw new Exception("Senha vazia");

            Encoding encoding = Encoding.UTF8;
            StringBuilder stringBuilder = new StringBuilder();

            using (SHA256 hasher = SHA256.Create())
            {
                byte[] hashedBytes = hasher.ComputeHash(encoding.GetBytes(senha));

                foreach (byte b in hashedBytes)
                    stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
