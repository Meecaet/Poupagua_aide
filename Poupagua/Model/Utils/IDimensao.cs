using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Utils
{
    public interface IDimensao
    {
        double VolumeLitros();
        double VolumeMetrosCubicos();
        bool ValidarDimensoes(out string erros);
    }
}
