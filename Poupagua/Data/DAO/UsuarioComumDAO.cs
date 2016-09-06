using Model.Atributos;
using Model.Cadastro;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class UsuarioComumDAO : IDao<UsuarioComum>
    {
        string CurrentSqlCommand;
        KeyValuePair<string, object> CurrentParameter;
        Dictionary<string, object> ParameterCollection;

        public UsuarioComumDAO()
        {
            ParameterCollection = new Dictionary<string, object>();
        }

        public bool AtualizarLinha(UsuarioComum entity, out string messsage)
        {
            throw new NotImplementedException();
        }

        public UsuarioComum ConsultaLinha(int key, bool lazy = true)
        {
            string where = "ID_USUARIO = @PARAM1";
            return ConsultaLinhas(where, lazy, key.ToString()).DefaultIfEmpty(null).FirstOrDefault();
        }

        public UsuarioComum ConsultaLinha(string where, bool lazy = true, params string[] parameters)
        {
            return ConsultaLinhas(where, lazy, parameters).DefaultIfEmpty(null).FirstOrDefault();
        }

        public List<UsuarioComum> ConsultaLinhas(string where, bool lazy = true, params string[] parameters)
        {
            List<UsuarioComum> usuarios = new List<UsuarioComum>();

            UsuarioComum currentUsuario;
            CurrentSqlCommand = "SELECT ID_USUARIO, NOME, USER_NAME, CPF, SENHA, ADMINISTRADOR FROM USUARIO WHERE " + where;
            ParameterCollection.Clear();

            for (int i = 0; i < parameters.Length; i++)
                ParameterCollection.Add(string.Format("@PARAM{0}", i + 1), parameters[i]);

            MySqlDataReader reader = (MySqlDataReader)ConnectionSingleton.GetData(CurrentSqlCommand, ParameterCollection, true);
            if (reader.HasRows)
            {
                int admInt;

                while (reader.Read())
                {
                    if (!(reader[5] is DBNull))
                        admInt = Convert.ToInt32(reader[5]);
                    else
                        admInt = 1;

                    currentUsuario = new UsuarioComum(Convert.ToInt32(reader[0]), reader[4].ToString(), admInt == 0);
                    currentUsuario.Nome = reader[1].ToString();
                    currentUsuario.NomeUsuario = reader[2].ToString();
                    currentUsuario.CPF = reader[3].ToString();

                    usuarios.Add(currentUsuario);
                }

                ConnectionSingleton.FinishDataReader(reader);
            }

            if (lazy)
            {
                foreach (UsuarioComum usuario in usuarios)
                {
                    ContatoDAO contatoDao = new ContatoDAO();
                    usuario.Contatos = contatoDao.ConsultaLinhas("ID_USUARIO = @PARAM1", false, usuario.Id.ToString());
                }                
            }

            return usuarios;          
        }

        public bool InserirLinha(UsuarioComum entity, out string messsage)
        {
            if (entity.Id > 0)
                throw new Exception("Usuário já presente no banco de dados.");

            bool result = false;
            string internalContatoMessage, internalResidenciaMessagem;

            CurrentSqlCommand = "INSERT INTO Usuario(";
            string values = " VALUES(";

            #region Columns

            if (!string.IsNullOrEmpty(entity.Nome))
            {
                CurrentSqlCommand += "NOME,";
                values += string.Format("'{0}',", entity.Nome);
            }

            if (!string.IsNullOrEmpty(entity.NomeUsuario))
            {
                CurrentSqlCommand += "USER_NAME,";
                values += string.Format("'{0}',", entity.NomeUsuario);
            }

            if (!string.IsNullOrEmpty(entity.Nome))
            {
                CurrentSqlCommand += "CPF,";
                values += string.Format("'{0}',", entity.CPF);
            }

            if (entity.Administrador)
            {
                CurrentSqlCommand += "ADMINISTRADOR,";
                values += string.Format("{0},", 0);
            }
            else
            {
                CurrentSqlCommand += "ADMINISTRADOR,";
                values += string.Format("{0},", 1);
            }

            #endregion

            if (CurrentSqlCommand.EndsWith(","))
            {
                CurrentSqlCommand = CurrentSqlCommand.Remove(CurrentSqlCommand.Length - 1);
                CurrentSqlCommand += ") ";
            }

            if (values.EndsWith(","))
            {
                values = values.Remove(values.Length - 1);
                values += ")";
            }

            CurrentSqlCommand += values;
            result = ConnectionSingleton.ExecuteCommand(CurrentSqlCommand);

            if (result)
                messsage = "Usuário inserido com sucesso.";
            else
                messsage = "Erro ao se inserir o usuário";

            if (result)
            {
                if (entity.Contatos != null && entity.Contatos.Count > 0)
                {
                    ContatoDAO contatoDao = new ContatoDAO();
                    foreach (Contato contato in entity.Contatos)
                    {
                        contatoDao.InserirLinha(contato, out internalContatoMessage);
                        messsage += string.Format(". {0}", internalContatoMessage);
                    }
                }

                if (entity.Residencias != null && entity.Residencias.Count > 0)
                {
                    //TODO: Add ResidenciaDAO
                }
            }

            return result;
        }

        public bool RemoverLinha(UsuarioComum entity, out string messsage)
        {
            throw new NotImplementedException();
        }

        private bool InserirLinhaAutoInsertMode(UsuarioComum entity, out string messsage)
        {
            bool result = false;
            CurrentSqlCommand = "INSERT INTO Usuario(";
            string values = " VALUES(";

            PropertyInfo[] propertiesInfo = entity.GetType().GetProperties();

            for (int i = 0; i < propertiesInfo.Length; i++)
            {
                PropertyInfo info = propertiesInfo[i];
                if (info.CustomAttributes.Count() > 0)
                {
                    Coluna attrib = info.GetCustomAttribute<Coluna>(true);
                    if (attrib != null)
                    {
                        CurrentSqlCommand += string.Format("{0},", attrib.Nome);

                        if (info.PropertyType == typeof(string))
                            values += string.Format("'{0}',", info.GetValue(entity));
                        else if (info.PropertyType == typeof(int))
                            values += string.Format("{0},", info.GetValue(entity));
                    }
                }
            }

            if (CurrentSqlCommand.EndsWith(","))
            {
                CurrentSqlCommand = CurrentSqlCommand.Remove(CurrentSqlCommand.Length - 1);
                CurrentSqlCommand += ") ";
            }

            if (values.EndsWith(","))
            {
                values = values.Remove(values.Length - 1);
                values += ")";
            }

            CurrentSqlCommand += values;
            result = ConnectionSingleton.ExecuteCommand(CurrentSqlCommand);

            if (result)
                messsage = "Usuário inserido com sucesso.";
            else
                messsage = "Erro ao se inserir o usuário";

            return result;

        }
    }
}
