using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Atributos
{
    public class ColunaChave : Attribute
    {
        public string Nome { get; private set; }
        public ColunaChave(string nome)
        {
            this.Nome = nome;
        }
    }
}
