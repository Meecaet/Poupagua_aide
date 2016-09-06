using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Atributos
{
    public class Coluna : Attribute
    {
        public string Nome;
        public Type Tipo;

        public Coluna(string nome, Type tipo)
        {
            this.Nome = nome;
            Tipo = tipo;
        }
    }
}
