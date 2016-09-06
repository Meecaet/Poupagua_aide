using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Consumo
{
    public class CaixaQuadrangular : CaixaGenerica
    {
        private double altura, largura, comprimento;
        private double[] alturas, larguras, comprimentos;
        private bool CaixaSimples;

        private string errosDeValidacao;

        public CaixaQuadrangular(double altura, double largura, double comprimento)
        {
            this.altura = altura;
            this.largura = largura;
            this.comprimento = comprimento;

            CaixaSimples = true;

            if(ValidarDimensoes(out errosDeValidacao))
                throw new Exception(errosDeValidacao);
        }

        public CaixaQuadrangular(double[] alturas, double[] larguras, double[] comprimentos)
        {
            this.alturas = alturas;
            this.larguras = larguras;
            this.comprimentos = comprimentos;

            CaixaSimples = false;
            
            if (ValidarDimensoes(out errosDeValidacao))
                throw new Exception(errosDeValidacao);
        }
        
        public override double VolumeLitros()
        {
            double totalVolume = 0;

            if (CaixaSimples)
            {
                totalVolume = altura * largura * comprimento;
            }
            else
            {
                int commonLenght = alturas.Length;

                for (int i = 0; i < commonLenght; i++)
                {
                    totalVolume += (alturas[i] * larguras[i] * comprimentos[i]);
                }
            }

            return totalVolume;
        }

        public override double VolumeMetrosCubicos()
        {
            double totalVolumeInLiters = VolumeLitros();           

            return totalVolumeInLiters / 1000;
        }

        public override bool ValidarDimensoes(out string erros)
        {
            bool Valido = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (CaixaSimples)
            {
                if (altura == 0 || largura == 0 || comprimento == 0)
                {
                    if (altura == 0)
                        stringBuilder.AppendLine("Altura está com o valor 0 (zero)");

                    if (largura == 0)
                        stringBuilder.AppendLine("Largura está com o valor 0 (zero)");

                    if (comprimento == 0)
                        stringBuilder.AppendLine("Comprimento está com o valor 0 (zero)");
                }
            }
            else
            {
                if (alturas.Any(d => d == 0) || larguras.Any(d => d == 0) || comprimentos.Any(d => d == 0))
                {
                    if (alturas.Any(d => d == 0))
                        stringBuilder.AppendLine(string.Format("{0} altura(s) está(ão) com o valor 0 (zero)", alturas.Count(d => d == 0)));

                    if (larguras.Any(d => d == 0))
                        stringBuilder.AppendLine(string.Format("{0} largura(s) está(ão) com o valor 0 (zero)", alturas.Count(d => d == 0)));

                    if (comprimentos.Any(d => d == 0))
                        stringBuilder.AppendLine(string.Format("{0} comprimento(s) está(ão) com o valor 0 (zero)", alturas.Count(d => d == 0)));
                }
            }

            erros = stringBuilder.ToString();
            return Valido;
        }
    }
}
