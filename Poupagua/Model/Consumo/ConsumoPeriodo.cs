using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Consumo
{
    public class ConsumoPeriodo
    {
        public DateTime InicioPeriodo { get; set; }
        public DateTime FimPeriodo { get; set; }

        public List<Consumo> Consumos { get; set; }

        public double ConsumoEmLitros()
        {
            double consumoPeriodo = 0;

            if (Consumos != null)
                consumoPeriodo = Consumos.Where(c => c.TimeStampMedicao >= InicioPeriodo && c.TimeStampMedicao <= FimPeriodo).Sum(c => c.FluxoMedido);

            return consumoPeriodo;
        }

        public double ConsumoEmMetrosCubicos()
        {
            double consumo = ConsumoEmLitros();
            return consumo / 1000;
        }
    }
}
