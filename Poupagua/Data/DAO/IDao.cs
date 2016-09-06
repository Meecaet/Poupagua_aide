using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public interface IDao<T> where T: class
    {
        T ConsultaLinha(int key, bool lazy = true);
        T ConsultaLinha(string where, bool lazy = true, params string[] parameters);
        List<T> ConsultaLinhas(string where, bool lazy = true, params string[] parameters);

        bool InserirLinha(T entity, out string messsage);
        bool AtualizarLinha(T entity, out string messsage);
        bool RemoverLinha(T entity, out string messsage);
    }
}
