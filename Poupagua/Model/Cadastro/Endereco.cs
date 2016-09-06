using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cadastro
{
    public class Endereco
    {
        [Atributos.Coluna("LOGRADOURO", typeof(double))]
        public string Logradouro { get; set; }
        [Atributos.Coluna("NUMERO", typeof(double))]
        public string Numero { get; set; }
        [Atributos.Coluna("COMPLEMENTO", typeof(double))]
        public string Complemento { get; set; }
        [Atributos.Coluna("BAIRRO", typeof(double))]
        public string Bairro { get; set; }
        [Atributos.Coluna("MUNICIPIO", typeof(double))]
        public string Municipio { get; set; }
        [Atributos.Coluna("UF", typeof(double))]
        public string UF { get; set; }
        [Atributos.Coluna("CEP", typeof(double))]
        public string CEP { get; set; }
        [Atributos.Coluna("TIPO_RESIDENCIA", typeof(int))]
        public TipoResidencia TipoDaResidencia { get; set; }
    }

    public enum TipoResidencia
    {
        Casa = 0,
        Apartamento = 1,
        Edicula = 2,
        Chacara = 3,
        Choupana = 4,
        Casebre = 5
    }
}
