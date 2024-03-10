using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class TablePolozka : ITable<TypPolozky>
    {
        public void Delete(TypPolozky p)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("delete from typ_polozky where jmeno = @name;", Conn);
                com.Parameters.Add(new SqlParameter("@name", p.Jmeno));

                com.ExecuteNonQuery();
            }
        }

        public TypPolozky GetById(int id)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("select typ_polozky.id,typ_polozky.jmeno,prodejce.jmeno,cena_ks from typ_polozky" +
                    " inner join prodejce on prodejce.id = prodejce_id" +
                    " where typ_polozky.id = @id;", Conn);
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

        public void Save(TypPolozky p)
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                int id;
                SqlCommand com = new SqlCommand("select id from prodejce where jmeno = @company;", Conn);
                com.Parameters.Add(new SqlParameter("@company", p.Prodejce));
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    reader.Read();
                    id = Convert.ToInt32(reader[0].ToString());
                }

                com = new SqlCommand("insert into typ_polozky(prodejce_id,jmeno,cena_ks) values (@id,@name,@price);", Conn);
                com.Parameters.Add(new SqlParameter("@id", id));
                com.Parameters.Add(new SqlParameter("@name", p.Jmeno));
                com.Parameters.Add(new SqlParameter("@price", p.Cena));
                com.ExecuteNonQuery();

            }
        }

        public override string ToString()
        {
            SqlConnection Conn;
            using (Conn = DatabaseSingleton.GetInstance())
            {
                SqlCommand com = new SqlCommand("select top 1 id from typ_polozky order by id desc", Conn);
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

        private TypPolozky CreateNew(SqlDataReader reader)
        {
            return new TypPolozky(
                Convert.ToInt32(reader[0].ToString()),
                reader[1].ToString(),
                reader[2].ToString(),
                Convert.ToInt32(reader[3].ToString())
                );
        }
    }
}
