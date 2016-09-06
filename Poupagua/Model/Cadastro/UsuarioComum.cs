using Model.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public class UsuarioComum : Usuario
    {
        public List<Residencia> Residencias { get; set; }

        public UsuarioComum():base()
        {
            this.Residencias = new List<Residencia>();
        }

        public UsuarioComum(int Id, string hashedPassword, bool adm) : base(Id, hashedPassword, adm)
        {
            this.Residencias = new List<Residencia>();
        }
    }
}
