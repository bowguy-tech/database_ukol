using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class TableProdejce : ITable<Prodejce>
    {
        public void Delete(Prodejce p)
        {
            SqlConnection conn = null;
            using(conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("delete prodejce where jmeno = @jmeno;", conn);
                com.Parameters.Add(new SqlParameter("@jmeno",p.Jmeno));

                com.ExecuteNonQuery();
            }
        }

        public Prodejce GetById(int id)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand(
                    "select prodejce.id, prodejce.jmeno, mesto.jmeno, adresa.ulice, adresa.cislo from prodejce" +
                    " inner join adresa on adresa.id = adresa_id" +
                    " inner join mesto on adresa.mesto_id = mesto.id" +
                    " where prodejce.id = @id;"
                    , Conn);
                com.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader;

                using (reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return CreateNew(reader);
                    }

                    //nenasel se zakaznik
                    return null;
                }
            }
        }

        public void Save(Prodejce p)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                ///reseni adresy

                //mesto
                SqlCommand com2 = new SqlCommand("select * from mesto where (jmeno = @city);", Conn);
                com2.Parameters.Add(new SqlParameter("@city", p.AdressCity));
                SqlCommand com3 = null;
                using (SqlDataReader reader = com2.ExecuteReader())
                {
                    //podiva jestli mesto je v databazi
                    if (!reader.HasRows)
                    {
                        //jestli ne tak se prida
                        com3 = new SqlCommand("insert into mesto (jmeno) values (@city);", Conn);
                        com3.Parameters.Add(new SqlParameter("@city", p.AdressCity));
                    }
                }
                if (com3 != null)
                {
                    com3.ExecuteNonQuery();
                }

                //tvoreni nove adresy
                com2 = new SqlCommand("insert into adresa (mesto_id,ulice,cislo) values ((select id from mesto where jmeno = @city),@street,@number)", Conn);
                com2.Parameters.Add(new SqlParameter("@city", p.AdressCity));
                com2.Parameters.Add(new SqlParameter("@street", p.AdressStreet));
                com2.Parameters.Add(new SqlParameter("@number", p.AdressNum));
                com2.ExecuteNonQuery();

                int cislo;

                //ziskavani id noveho vytvoreneho adresy
                com2 = new SqlCommand("Select @@Identity", Conn);
                using (SqlDataReader reader = com2.ExecuteReader())
                {
                    reader.Read();

                    cislo = decimal.ToInt32(reader.GetDecimal(0));
                }

                //tvoreni prodejce
                SqlCommand com = new SqlCommand("insert into prodejce (adresa_id,jmeno) values (@adresa,@jmeno);", Conn);
                com.Parameters.Add(new SqlParameter("@adresa", cislo));
                com.Parameters.Add(new SqlParameter("@jmeno", p.Jmeno));
                com.ExecuteNonQuery();

            }
        }
        public override string ToString()
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("select top 1 id from prodejce order by id desc", Conn);
                SqlDataReader reader;
                int top = 0;
                string output = "";

                using (reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        top = Convert.ToInt32(reader[0]);
                    }
                }
                for (int i = 0; i < top; i++)
                {
                    if (GetById(i) != null)
                    {
                        output += GetById(i).ToString() + "\n";
                    }
                }
                return output;
            }
        }
        private Prodejce CreateNew(SqlDataReader reader)
        {
            return new Prodejce(
                Convert.ToInt32(reader[0].ToString()),
                reader[1].ToString(),
                reader[2].ToString(),
                reader[3].ToString(),
                Convert.ToInt32(reader[4].ToString())
                );
        }
    }
}
