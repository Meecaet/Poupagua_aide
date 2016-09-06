using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data
{
    public static class ConnectionSingleton
    {
        private static MySqlConnection Connection;
        private static MySqlTransaction CurrentTransaction;

        public static void Init()
        {
            Connection = new MySql.Data.MySqlClient.MySqlConnection(Parameters.Default.ConnectionString);
        }

        private static void Connect()
        {
            if (Connection == null)
                throw new InvalidOperationException("Conexão não estabelecida");

            if(Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
        }

        private static void Disconnect()
        {
            if (Connection == null)
                throw new InvalidOperationException("Conexão não estabelecida");

            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }

        private static void StartTransaction()
        {
            if (Connection == null)
                throw new InvalidOperationException("Conexão não estabelecida");

            if (Connection.State == System.Data.ConnectionState.Open)
                CurrentTransaction = Connection.BeginTransaction();
        }

        private static void EndTransaction(bool commit)
        {
            if (Connection == null)
                throw new InvalidOperationException("Conexão não estabelecida");

            if (Connection.State == System.Data.ConnectionState.Open
                && CurrentTransaction != null)
            {
                if (commit)
                    CurrentTransaction.Commit();
                else
                    CurrentTransaction.Rollback();

                CurrentTransaction.Dispose();
                CurrentTransaction = null;
            }
                
                
        }

        private static MySqlDataReader GetDataReader(MySqlCommand command)
        {
            Connect();

            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        private static DataTable GetDataTable(MySqlCommand command)
        {
            try
            {
                Connect();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            finally
            {
                Disconnect();
            }
        }

        internal static void FinishDataReader(MySqlDataReader dataReader)
        {
            if (!dataReader.IsClosed)
                dataReader.Close();

            dataReader = null;
            Disconnect();
        }

        public static object GetData(string selectSql, Dictionary<string, object> parameters, bool reader = true)
        {
            if (string.IsNullOrEmpty(selectSql))
                throw new Exception("Comando de consulta vazio");

            object data = null;

            MySqlCommand selectCommand = new MySqlCommand();
            selectCommand.CommandText = selectSql;
            selectCommand.Connection = Connection;

            if (parameters != null && parameters.Count > 0)
                foreach (KeyValuePair<string, object> parameter in parameters)
                    selectCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);

            if (reader)
                data = GetDataReader(selectCommand);
            else
                data = GetDataTable(selectCommand);

            return data;
        }

        public static object GetData(string selectSql, MySqlParameterCollection parameters, bool reader = true)
        {
            if (string.IsNullOrEmpty(selectSql))
                throw new Exception("Comando de consulta vazio");

            object data = null;

            MySqlCommand selectCommand = new MySqlCommand();
            selectCommand.CommandText = selectSql;

            foreach (MySqlParameter parameter in parameters)
                selectCommand.Parameters.Add(parameter);
            
            if (reader)
                data = GetDataReader(selectCommand);
            else
                data = GetDataTable(selectCommand);

            return data;
        }

        public static bool ExecuteCommand(string sqlCommand)
        {
            Connect();
            StartTransaction();
            
            try
            {
                MySqlCommand command = new MySqlCommand(sqlCommand);
                command.Connection = Connection;

                command.ExecuteNonQuery();

                EndTransaction(true);

                return true;
            }
            catch(Exception e)
            {
                EndTransaction(false);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
    }    
}
