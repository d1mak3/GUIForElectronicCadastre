using Npgsql;
using System.Data;

namespace GUIForEclectronicCadastre
{
    public class DatabaseHandler
    {
        private static NpgsqlConnection databaseConnection;

        public DatabaseHandler(string userID, string password, string databaseName)
        {            
            databaseConnection = new NpgsqlConnection("Server=" + "localhost" + ";Port=" + "5432" + ";Database=" + databaseName + ";User ID=" + userID + ";Password=" + password + ";");
        }

        public string ConnectToDatabase()
        {
            try
            {
                databaseConnection.Open();
                return "Successfuly connected!";
            }
            catch
            {
                return "Wrong connection data!";
            }
        }

        public DataTable ExecuteQuery(string queryToExecute)
        {
            DataTable dataTable = new DataTable();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(queryToExecute, databaseConnection);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void Disconnect()
        {
            databaseConnection.Close();
        }
    }
}
