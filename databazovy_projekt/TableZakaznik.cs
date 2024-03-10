using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class TableZakaznik : ITable<Zakaznik>
    {
        
        public void Delete(Zakaznik z)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("delete from zakaznik where ((jmeno = @name) and (prijmeni = @surname))", Conn);
                com.Parameters.Add(new SqlParameter("@name",z.Jmeno));
                com.Parameters.Add(new SqlParameter("@surname", z.Prijmeni));

                com.ExecuteNonQuery();
            }
        }

        public Zakaznik? GetById(int id)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand(
                    "select zakaznik.jmeno,prijmeni,mesto.jmeno as mesto,adresa.ulice,adresa.cislo,zalozeni from zakaznik" +
                    " inner join adresa on adresa.id = zakaznik.adresa_id" +
                    " inner join mesto on mesto.id = mesto_id" +
                    " where (zakaznik.id = @id);"
                    ,Conn);
                com.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader;

                using (reader = com.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        return CreateNew(reader);
                    }

                    //nenasel se zakaznik
                    return null;
                }
            }
        }

        public void Save(Zakaznik z)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                ///reseni adresy

                //mesto
                SqlCommand com2 = new SqlCommand("select * from mesto where (jmeno = @city);", Conn);
                com2.Parameters.Add(new SqlParameter("@city",z.AdressCity));
                SqlCommand com3 = null;
                using (SqlDataReader reader = com2.ExecuteReader())
                {
                    //podiva jestli mesto je v databazi
                    if (!reader.HasRows)
                    {
                        //jestli ne tak se prida
                        com3 = new SqlCommand("insert into mesto (jmeno) values (@city);", Conn);
                        com3.Parameters.Add(new SqlParameter("@city", z.AdressCity));
                    }
                }
                if (com3 != null)
                {
                    com3.ExecuteNonQuery();
                }

                //tvoreni nove adresy
                com2 = new SqlCommand("insert into adresa (mesto_id,ulice,cislo) values ((select id from mesto where jmeno = @city),@street,@number)", Conn);
                com2.Parameters.Add(new SqlParameter("@city", z.AdressCity));
                com2.Parameters.Add(new SqlParameter("@street", z.AdressStreet));
                com2.Parameters.Add(new SqlParameter("@number", z.AdressNum));
                com2.ExecuteNonQuery();

                int cislo;

                //ziskavani id noveho vytvoreneho adresy
                com2 = new SqlCommand("Select @@Identity", Conn);
                using (SqlDataReader reader = com2.ExecuteReader())
                    {
                        reader.Read();
                        
                        cislo = decimal.ToInt32(reader.GetDecimal(0));
                    }

                //tvoreni zakaznika
                SqlCommand com = new SqlCommand("insert into zakaznik (adresa_id,jmeno,prijmeni,zalozeni) values (@adresa,@jmeno,@prijmeni,(select getdate()));", Conn);
                com.Parameters.Add(new SqlParameter("@adresa", cislo));
                com.Parameters.Add(new SqlParameter("@jmeno", z.Jmeno));
                com.Parameters.Add(new SqlParameter("@prijmeni", z.Prijmeni));
                com.ExecuteNonQuery();

            }
        }

        public override string ToString()
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand(
                    "select zakaznik.jmeno,prijmeni,mesto.jmeno as mesto,adresa.ulice,adresa.cislo,zalozeni from zakaznik" +
                    " inner join adresa on adresa.id = zakaznik.adresa_id" +
                    " inner join mesto on mesto.id = mesto_id;"
                    , Conn);

                using (SqlDataReader reader = com.ExecuteReader())
                {
                    string output = string.Empty;
                    while (reader.Read())
                    {
                        output += CreateNew(reader).ToString() + "\n";
                    }
                    return output;
                }

            }
        }

        //pouziva reader na vytvoreneni noveho instance zakaznika
        private Zakaznik CreateNew(SqlDataReader reader)
        {
            return new Zakaznik(
                reader[0].ToString(),
                reader[1].ToString(),
                reader[2].ToString(),
                reader[3].ToString(),
                Convert.ToInt32(reader[4].ToString()),
                reader[5].ToString()
            );
        }
    }
}
