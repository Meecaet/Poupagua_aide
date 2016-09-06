using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Consumo
{
    public class CaixaCilindrica : CaixaGenerica
    {
        private double raio, altura;
        private double[] raios, alturas;

        private bool CaixaSimples;

        private string errosDeValidacao;

        public CaixaCilindrica(double raio, double altura)
        {
            this.altura = altura;
            this.raio = raio;

            CaixaSimples = true;

            if (ValidarDimensoes(out errosDeValidacao))
                throw new Exception(errosDeValidacao);
        }

        public CaixaCilindrica(double[] raios, double[] alturas)
        {
            this.alturas = alturas;
            this.raios = raios;

            CaixaSimples = false;

            if (ValidarDimensoes(out errosDeValidacao))
                throw new Exception(errosDeValidacao);
        }

        public override double VolumeLitros()
        {
            double totalVolume = 0;

            if (CaixaSimples)
            {
                totalVolume = Math.PI * Math.Pow(raio, 2) * altura;
            }
            else
            {
                int commonLenght = alturas.Length;

                for (int i = 0; i < commonLenght; i++)
                {
                    totalVolume += Math.PI * Math.Pow(raios[i], 2) * alturas[i];
                }
            }

            return totalVolume;
        }

        public override double VolumeMetrosCubicos()
        {
            double volumeInLiters = VolumeLitros();
            return volumeInLiters / 1000;
        }

        public override bool ValidarDimensoes(out string erros)
        {
            bool Valido = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (CaixaSimples)
            {
                if (altura == 0 || raio == 0 )
                {
                    if (altura == 0)
                        stringBuilder.AppendLine("Altura está com o valor 0 (zero)");

                    if (raio == 0)
                        stringBuilder.AppendLine("Raio está com o valor 0 (zero)");
                }
            }
            else
            {
                if (alturas.Any(d => d == 0) || raios.Any(d => d == 0))
                {
                    if (alturas.Any(d => d == 0))
                        stringBuilder.AppendLine(string.Format("{0} altura(s) está(ão) com o valor 0 (zero)", alturas.Count(d => d == 0)));

                    if (raios.Any(d => d == 0))
                        stringBuilder.AppendLine(string.Format("{0} raio(s) está(ão) com o valor 0 (zero)", raios.Count(d => d == 0)));
                    
                }
            }

            erros = stringBuilder.ToString();
            return Valido;
        }
    }
}
