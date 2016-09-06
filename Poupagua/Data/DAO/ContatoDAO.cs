using Model.Cadastro;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAO
{
    public class ContatoDAO : IDao<Contato>
    {
        string CurrentSqlCommand;
        KeyValuePair<string, object> CurrentParameter;
        Dictionary<string, object> ParameterCollection;

        public ContatoDAO()
        {
            ParameterCollection = new Dictionary<string, object>();
        }

        public bool AtualizarLinha(Contato entity, out string messsage)
        {
            if (entity.Id <= 0)
                throw new Exception("Contato não existe no banco de dados");

            try
            {
                bool result;
                CurrentSqlCommand = "UPDATE Contato SET ";


                #region Columns

                if (!string.IsNullOrEmpty(entity.DDD))
                    CurrentSqlCommand += string.Format("DDD = '{0}',", entity.DDD);

                if (!string.IsNullOrEmpty(entity.Telefone))
                    CurrentSqlCommand += string.Format("TELEFONE = '{0}',", entity.Telefone);

                if (!string.IsNullOrEmpty(entity.Email))
                    CurrentSqlCommand += string.Format("EMAIL = '{0}',", entity.Email);

                if (entity.Usuario != null && entity.Usuario.Id > 0)
                    CurrentSqlCommand += string.Format("ID_USUARIO = {0},", entity.Usuario.Id);

                #endregion

                if (CurrentSqlCommand.EndsWith(","))
                    CurrentSqlCommand = CurrentSqlCommand.Remove(CurrentSqlCommand.Length - 1);

                CurrentSqlCommand += string.Format(" WHERE ID_CONTATO = {0}", entity.Id);
                result = ConnectionSingleton.ExecuteCommand(CurrentSqlCommand);

                if (result)
                    messsage = "Contato atualizado com sucesso.";
                else
                    messsage = "Erro ao se atualizar o contato";

                return result;

            }
            catch (Exception e)
            {
                messsage = e.Message;
                return false;
            }
        }

        public Contato ConsultaLinha(int key, bool lazy = true)
        {
            string where = "ID_CONTATO = @PARAM1";
            return ConsultaLinhas(where, lazy, key.ToString()).DefaultIfEmpty(null).FirstOrDefault();
        }

        public Contato ConsultaLinha(string where, bool lazy = true, params string[] parameters)
        {
            return ConsultaLinhas(where, lazy, parameters).DefaultIfEmpty(null).FirstOrDefault();
        }

        public List<Contato> ConsultaLinhas(string where, bool lazy = true, params string[] parameters)
        {
            List<Contato> contatos = new List<Contato>();
            CurrentSqlCommand = "SELECT ID_CONTATO, DDD, TELEFONE, EMAIL, ID_USUARIO FROM Contato WHERE " + where;

            ParameterCollection.Clear();

            for (int i = 0; i < parameters.Length; i++)
                ParameterCollection.Add(string.Format("@PARAM{0}", i + 1), parameters[i]);

            MySqlDataReader reader = (MySqlDataReader)ConnectionSingleton.GetData(CurrentSqlCommand, ParameterCollection, true);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Contato contato = new Contato(Convert.ToInt32(reader[0]));
                    contato.DDD = reader[1].ToString();
                    contato.Telefone = reader[2].ToString();
                    contato.Email = reader[3].ToString();

                    contatos.Add(contato);
                }

                ConnectionSingleton.FinishDataReader(reader);
            }

            return contatos;
        }

        public bool InserirLinha(Contato entity, out string messsage)
        {
            if (entity.Id > 0)
                throw new Exception("Contato já existe no banco de dados.");

            bool result = false;

            CurrentSqlCommand = "INSERT INTO Contato(";
            string values = " VALUES(";

            #region Columns

            if (!string.IsNullOrEmpty(entity.DDD))
            {
                CurrentSqlCommand += "DDD,";
                values += string.Format("'{0}',", entity.DDD);
            }

            if (!string.IsNullOrEmpty(entity.Telefone))
            {
                CurrentSqlCommand += "TELEFONE,";
                values += string.Format("'{0}',", entity.Telefone);
            }            

            if (!string.IsNullOrEmpty(entity.Email))
            {
                CurrentSqlCommand += "EMAIL,";
                values += string.Format("'{0}',", entity.Email);
            }

            if (entity.Usuario != null && entity.Usuario.Id > 0)
            {
                CurrentSqlCommand += "ID_USUARIO,";
                values += string.Format("'{0}',", entity.Usuario.Id);
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
                messsage = "Contato inserido com sucesso.";
            else
                messsage = "Erro ao se inserir o contato";

            return result;
        }

        public bool RemoverLinha(Contato entity, out string messsage)
        {
            if (entity.Id <= 0)
                throw new Exception("Contato não existe no banco de dados.");

            try
            {
                bool result;

                CurrentSqlCommand = string.Format("DELETE FROM Contato WHERE ID_CONTATO = {0}", entity.Id);
                result = ConnectionSingleton.ExecuteCommand(CurrentSqlCommand);

                if (result)
                    messsage = "Contato removido com sucesso";
                else
                    messsage = "Contato não removido";

                return result;
            }
            catch (Exception e)
            {
                messsage = e.Message;
                return false;
            }            
        }
    }
}
