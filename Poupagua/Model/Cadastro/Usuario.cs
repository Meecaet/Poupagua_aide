using Model.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public abstract class Usuario
    {
        Login login;

        [ColunaChave("ID_USUARIO")]
        public int Id { get; private set; }
        [Coluna("NOME", typeof(string))]
        public string Nome { get; set; }
        [Coluna("USER_NAME", typeof(string))]
        public string NomeUsuario { get; set; }
        [Coluna("CPF", typeof(string))]
        public string CPF { get; set; }
        public bool Administrador { get; private set; }

        [Coluna("SENHA", typeof(string))]
        private string hashedPassword;
        
        

        public List<Contato> Contatos { get; set; }

        public Usuario(int Id)
        {
            this.Id = Id;
        }

        public Usuario(int Id, string hashedPassword, bool adm)
        {
            this.Id = Id;
            this.hashedPassword = hashedPassword;
            this.Administrador = adm;

            login = new Login(this);
            this.Contatos = new List<Contato>();
        }

        public Usuario()
        {
            login = new Login(this);
            this.Contatos = new List<Contato>();
        }

        public void SetSenha(string barePassword)
        {
            this.hashedPassword = login.HashPassword(barePassword);
        }

        public bool Autenticar(string barePassword)
        {
            SetSenha(barePassword);
            return login.Autenticar(this.hashedPassword);          
        }
    }
}
