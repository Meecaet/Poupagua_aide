using Model.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public class Contato
    {
        [Coluna("ID_CONTATO", typeof(string))]
        public int Id { get; private set; }
        [Coluna("DDD", typeof(string))]
        public string DDD { get; set; }
        [Coluna("TELEFONE", typeof(string))]
        public string Telefone { get; set; }
        [Coluna("EMAIL", typeof(string))]
        public string Email { get; set; }

        public Usuario Usuario { get; set; }

        public Contato()
        {

        }

        public Contato(int Id)
        {
            this.Id = Id;
        }
             
        public bool ContatoValido;

        public bool ValidarCPF;
        public bool ValidarTelefone;
        public bool ValidarEmail;
    }
}
