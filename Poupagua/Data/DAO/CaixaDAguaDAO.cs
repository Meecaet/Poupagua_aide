using Model.Consumo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class CaixaDAguaDAO : IDao<ICaixaDagua>
    {
        string CurrentSqlCommand;
        KeyValuePair<string, object> CurrentParameter;
        Dictionary<string, object> ParameterCollection;

        public CaixaDAguaDAO()
        {
            ParameterCollection = new Dictionary<string, object>();
        }

        public bool AtualizarLinha(ICaixaDagua entity, out string messsage)
        {
            throw new NotImplementedException();
        }

        public ICaixaDagua ConsultaLinha(int key)
        {
            Type caixaType = this.GetType().GetGenericParameterConstraints()[0];
            CurrentSqlCommand = "SELECT * FROM ";

            if (caixaType == typeof(CaixaQuadrangular))
                CurrentSqlCommand += " CAIXA_QUADRANGULAR ";
            else if (caixaType == typeof(CaixaCilindrica))
                CurrentSqlCommand += " CAIXA_CILINDRICA ";
            else
                CurrentSqlCommand += " CAIXA_DAGUA ";

            CurrentSqlCommand += " WHERE CAIXA_ID = @PARAM1";
            ParameterCollection.Clear();
            ParameterCollection.Add("PARAM1", key);

            return (ICaixaDagua)ConnectionSingleton.GetData(CurrentSqlCommand, ParameterCollection, true);
        }

        public ICaixaDagua ConsultaLinha(string where, params string[] parameters)
        {
            Type caixaType = this.GetType().GetGenericParameterConstraints()[0];
            CurrentSqlCommand = "SELECT * FROM WHERE ";

            if (caixaType == typeof(CaixaQuadrangular))
                CurrentSqlCommand += " CAIXA_QUADRANGULAR ";
            else if (caixaType == typeof(CaixaCilindrica))
                CurrentSqlCommand += " CAIXA_CILINDRICA ";
            else
                CurrentSqlCommand += " CAIXA_DAGUA ";

            CurrentSqlCommand += where;
            ParameterCollection.Clear();

            for (int i = 0; i < parameters.Length; i++)
                ParameterCollection.Add(string.Format("@PARAM{0}", i), parameters[i]);

            return (ICaixaDagua)ConnectionSingleton.GetData(CurrentSqlCommand, ParameterCollection, true);
        }

        public List<ICaixaDagua> ConsultaLinhas(string where, params string[] parameters)
        {
            Type caixaType = this.GetType().GetGenericParameterConstraints()[0];
            CurrentSqlCommand = "SELECT * FROM WHERE";

            if (caixaType == typeof(CaixaQuadrangular))
                CurrentSqlCommand += " CAIXA_QUADRANGULAR ";
            else if (caixaType == typeof(CaixaCilindrica))
                CurrentSqlCommand += " CAIXA_CILINDRICA ";
            else
                CurrentSqlCommand += " CAIXA_DAGUA ";

            CurrentSqlCommand += where;
            ParameterCollection.Clear();

            for (int i = 0; i < parameters.Length; i++)
                ParameterCollection.Add(string.Format("@PARAM{0}", i), parameters[i]);

            return (List<ICaixaDagua>)ConnectionSingleton.GetData(CurrentSqlCommand, ParameterCollection, true);
        }

        public bool InserirLinha(ICaixaDagua entity, out string messsage)
        {
            messsage = "";
            return false;

            //Type caixaType = entity.GetType();
            //caixaType.
        }

        public bool RemoverLinha(ICaixaDagua entity, out string messsage)
        {
            throw new NotImplementedException();
        }

        public ICaixaDagua ConsultaLinha(int key, bool lazy = true)
        {
            throw new NotImplementedException();
        }

        public ICaixaDagua ConsultaLinha(string where, bool lazy = true, params string[] parameters)
        {
            throw new NotImplementedException();
        }

        public List<ICaixaDagua> ConsultaLinhas(string where, bool lazy = true, params string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
