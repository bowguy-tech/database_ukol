using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    internal class CommandChangeDelivered
    {
        public void Execute(int id)
        {
            TableObjednavka to = new TableObjednavka();
            to.Change(id);
        }
    }
}
