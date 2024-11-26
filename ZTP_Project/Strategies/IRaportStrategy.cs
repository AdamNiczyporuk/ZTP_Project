using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Strategies
{
    public interface IRaportStrategy

    {
        string GenerujRaport(List<Wydatek> wydatki);

    }
}
