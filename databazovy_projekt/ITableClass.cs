using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    public interface ITableClass
    {
        int Id { get; set; }

        string ToString();
    }
}
