using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace databazovy_projekt
{
    internal class DatabaseSingleton
    {
        private static SqlConnection Conn;

        public static SqlConnection GetInstance()
        {
            if ((Conn == null) || (Conn.State == ConnectionState.Closed))
            {
                //pouzivam databaze spoluzaka protoze mi neslo poridit vlastni D:
                SqlConnectionStringBuilder ConnString = new SqlConnectionStringBuilder();
                ConnString.UserID = "kremlik";
                ConnString.Password = "pzoMwfFn_22";
                ConnString.InitialCatalog = "kremlik";
                ConnString.DataSource = "193.85.203.188";

                Conn = new SqlConnection(ConnString.ConnectionString);
                Conn.Open();
            }

            return Conn;
        }

        public static void Close()
        {
            Conn.Close();
            Conn.Dispose();
            Conn = null;
        }
    }
}
