using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorators
{
    public class EksportDoCSV : EksportBase
    {
        public override string Eksportuj(List<Wydatek> wydatki)
        {
            var csv = "Nazwa, Kwota, Kategoria\n";

            foreach (var wydatek in wydatki)
            {
                csv += $"{wydatek.Nazwa}, {wydatek.Kwota}, {wydatek.Kategoria}\n";
            }

            return csv;
        }
    }

    public class EksportZDataDecorator : EksportBase
    {
        private readonly EksportBase _eksportBase;

        public EksportZDataDecorator(EksportBase eksportBase)
        {
            _eksportBase = eksportBase;
        }

        public override string Eksportuj(List<Wydatek> wydatki)
        {
            string wynik = _eksportBase.Eksportuj(wydatki);

            string data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            wynik = $"Data eksportu: {data}\n{wynik}";

            return wynik;
        }
    }

}
