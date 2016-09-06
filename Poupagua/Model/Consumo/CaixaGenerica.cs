using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Consumo
{
    public class CaixaGenerica : ICaixaDagua
    {
        //TODO: Define clear relation between box and consumption

        [Atributos.Coluna("VOLUME", typeof(double))]
        private double volumeEmLitros;        
        [Atributos.Coluna("FABRICANTE", typeof(string))]
        public string Fabricante { get; set; }
        [Atributos.Coluna("MATERIAL", typeof(string))]
        public string Material { get; set; }

        public CaixaGenerica()
        {

        }

        public CaixaGenerica(double volumeEmLitros)
        {
            this.volumeEmLitros = volumeEmLitros;
        }

        public virtual double VolumeLitros()
        {
            return volumeEmLitros;
        }

        public virtual double VolumeMetrosCubicos()
        {
            return volumeEmLitros / 1000;
        }

        public virtual bool ValidarDimensoes(out string erros)
        {
            erros = string.Empty;

            if (volumeEmLitros <= 0)
            {
                erros = "Volume zero ou negativo";
                return false;
            }

            return true;                
        }

        public virtual double ConsumoPeriodo(DateTime inicio, DateTime fim)
        {
            throw new NotImplementedException();
        }

        public virtual double ConsumoDoMes()
        {
            DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                fim = inicio.AddMonths(1);

            return ConsumoPeriodo(inicio, fim);
        }
    }
}
