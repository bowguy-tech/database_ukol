using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databazovy_projekt
{
    public abstract class Command
    {
        public abstract void Execute(ITableClass Instance);

    }
}
