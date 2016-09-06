using Model.Cadastro;
using Model.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Consumo
{
    public class Residencia
    {
        public Endereco Endereco { get; set; }
        public List<ICaixaDagua> CaixasDagua { get; set; }

        public double ConsumoDoMesEmLitros()
        {
            double consumo = 0;
            if (CaixasDagua != null)
                consumo = CaixasDagua.Sum(caixa => caixa.ConsumoDoMes());

            return consumo;
        }

        public double ConsumoDoMesEmMetrosCubicos()
        {
            double consumo = ConsumoDoMesEmLitros();
            return consumo / 1000;
        }

        //TODO: Needs to implement Consumption by range of time

        public double VolumeEmLitros()
        {
            double consumo = 0;
            if (CaixasDagua != null)
                consumo = CaixasDagua.Sum(caixa => caixa.VolumeLitros());

            return consumo;
        }

        public double VolumeEmMetrosCubicos()
        {
            return VolumeEmLitros() / 1000;
        }
    }
}
