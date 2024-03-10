using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class TableObjednavka : ITable<Objednavka>
    {
        public void Delete(Objednavka o)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                //zmazani jednotlivych polozek
                SqlCommand com = new SqlCommand("delete from polozka where objednavka_id = @id;", Conn);
                com.Parameters.Add(new SqlParameter("@id", o.Id));

                com.ExecuteNonQuery();

                //zmazani objednavka
                com = new SqlCommand("delete from objednavka where id = @id;", Conn);
                com.Parameters.Add(new SqlParameter("@id", o.Id));

                com.ExecuteNonQuery();
            }
        }

        public Objednavka GetById(int id)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                //ziskani objednavky
                SqlCommand com = new SqlCommand(
                    "select objednavka.id,zakaznik.jmeno,zakaznik.prijmeni,dorucena from objednavka " +
                    "inner join zakaznik on zakaznik.id = objednavka.zakaznik_id " +
                    "inner join polozka on polozka.objednavka_id = objednavka.id " +
                    "inner join typ_polozky on typ_polozky.id = polozka.polozka_id " +
                    "where objednavka.id = @id",
                    Conn);
                com.Parameters.Add(new SqlParameter("@id", id));
                Objednavka output = new Objednavka();
                SqlDataReader reader;

                using (reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(2))
                        {
                            Console.WriteLine("nothere");
                            return null;
                        }
                        output = CreateNew(reader);
                    }

                    
                }

                com = new SqlCommand("select jmeno,pocet_ks from polozka inner join typ_polozky on polozka_id = typ_polozky.id where objednavka_id = @id;", Conn);
                com.Parameters.Add(new SqlParameter("@id", id));
                using (reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try {
                        output.AddPolozka(new Polozka(reader[0].ToString(), Convert.ToInt32(reader[1].ToString())));
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                }
                return output;
            }
        }

        public void Save(Objednavka o)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                //vytvareni objednavky
                int id;
                SqlCommand com = new SqlCommand(
                    "insert into objednavka(zakaznik_id,dorucena) values ((select id from zakaznik " +
                    " where (zakaznik.jmeno = @name) and (zakaznik.prijmeni = @surname)),@delivered);"
                    , Conn);
                string[] jmeno = o.ZakCeleJmeno.Split(" ");
                com.Parameters.Add(new SqlParameter("@name", jmeno[0]));
                com.Parameters.Add(new SqlParameter("@surname", jmeno[1]));
                com.Parameters.Add(new SqlParameter("@delivered", o.Dorucena));
                com.ExecuteNonQuery();
            }
            using (Conn = DatabaseSingleton.GetInstance())
                {
                    //doplnovani polozky
                    foreach (Polozka p in o.GetPolozky())
                    {
                        SqlCommand com = new SqlCommand("insert into polozka(objednavka_id,polozka_id,pocet_ks) values ((select top 1 id from objednavka order by id desc),(select id from typ_polozky where(jmeno = @produktjmeno)),@pocet);", Conn);
                        com.Parameters.Add(new SqlParameter("@produktjmeno", p.Produkt));
                        com.Parameters.Add(new SqlParameter("@pocet", p.Pocet));
                        com.ExecuteNonQuery();
                    }
                }

            
        }

        public override string ToString()
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("select top 1 id from objednavka order by id desc", Conn);
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

        internal void Change(int id)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("update objednavka set dorucena = '1' where id = @id", Conn);
                com.Parameters.Add(new SqlParameter("@id", id));
                com.ExecuteNonQuery ();
            }
        }

        private Objednavka CreateNew(SqlDataReader reader)
        {
            return new Objednavka(
                Convert.ToInt32(reader[0].ToString()),
                reader[1].ToString() + " " + reader[2].ToString(),
                (reader[3].ToString() == "1")
            );
        }
    }
}
