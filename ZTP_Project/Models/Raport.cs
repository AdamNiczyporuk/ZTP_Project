using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Strategies;

namespace ZTP_Project.Models
{
    public class Raport
    {
        private readonly IRaportStrategy _raportStrategy;

        // Konstruktor przyjmujący strategię
        public Raport(IRaportStrategy raportStrategy)
        {
            _raportStrategy = raportStrategy;
        }

        // Metoda generująca raport na podstawie wydatków
        public string GenerujRaport(List<Wydatek> wydatki)
        {
            return _raportStrategy.GenerujRaport(wydatki);
        }
    }

}
