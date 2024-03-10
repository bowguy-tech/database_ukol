using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    public interface ITable<T>
    {
        T GetById(int id);
        void Delete(T entity);
        void Save(T entity);
        string ToString();
    }
}
