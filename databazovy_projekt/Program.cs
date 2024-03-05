using System;
using System.Data.SqlClient;

namespace databazovy_projekt
{

    class SelectStatement
    {

        static void Main()
        {
            Stuff();
            Console.ReadKey();
        }

        static void Stuff()
        {
            string connstr = @"Data Source=193.85.203.188;Initial Catalog=kremlik;User ID=kremlik;Password=pzoMwfFn_22";
            conn = new SqlConnection(constr);
            
            conn.Open();

            string sql = "select cislo from cool_table";

            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dataReader = com.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine(dataReader.GetString(0));
            }
            Console.WriteLine("reading complete");
            conn.Close();
        }
    }
}
