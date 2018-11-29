using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace HavFunService
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            try
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    string connstring = string.Format("Server=mysql.montpellier.epsi.fr; Port=5206; database={0}; UID=m.bonneville; password=blaskovitch", databaseName);
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Exception message :" + e.Message + "\nException StackTrace :" + e.StackTrace));
                return false;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
