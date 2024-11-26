using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorators
{
    public abstract class EksportBase
    { 
        public abstract string Eksportuj(List<Wydatek> wydatki);
    }
}
