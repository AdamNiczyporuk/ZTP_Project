using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorators
{
    public class EksportDoCSV
    {
        public string Eksportuj(List<Wydatek> wydatki)
        {
            return string.Join("\n", wydatki.Select(w => $"{w.Nazwa},{w.Kwota},{w.Kategoria}"));
        }
    }
}
