using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Consumo
{
    public interface ICaixaDagua
    {        
        bool ValidarDimensoes(out string erros);
        double VolumeLitros();
        double VolumeMetrosCubicos();

        double ConsumoPeriodo(DateTime inicio, DateTime fim);
        double ConsumoDoMes();
    }
}
