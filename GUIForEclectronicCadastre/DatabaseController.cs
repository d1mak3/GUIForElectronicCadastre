using Npgsql;
using System.Data;

namespace GUIForEclectronicCadastre
{
    public class DatabaseController
    {
        private static NpgsqlConnection databaseConnection;

        public DatabaseController(string userID, string password, string databaseName)
        {            
            databaseConnection = new NpgsqlConnection("Server=" + "localhost" + ";Port=" + "5432" + ";Database=" + databaseName + ";User ID=" + userID + ";Password=" + password + ";");
        }

        public DatabaseController()
        {

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

        public static DataTable ExecuteQuery(string queryToExecute)
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
