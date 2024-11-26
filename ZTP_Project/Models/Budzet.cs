using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.FactoryMethod;
using ZTP_Project.Strategies;

namespace ZTP_Project.Models
{
    public class Budzet
    {
        public decimal Przychody { get; set; }
        public decimal Limit { get; set; }
        public List<Wydatek> Wydatki { get; set; } = new List<Wydatek>();

        public string GenerujRaport(IRaportStrategy raportStrategy)
        {
            var raport = new Raport(raportStrategy);
            return raport.GenerujRaport(Wydatki);
        }

        public void DodajWydatek(IWydatekFactory factory, string nazwa, decimal kwota, string kategoria, DateTime data)
        {
            var wydatek = factory.UtworzWydatek(nazwa, kwota, kategoria, data);
            Wydatki.Add(wydatek);
        }

        public decimal ObliczSaldo()
        {
            return Przychody - Wydatki.Sum(x => x.Kwota);
        }
    }
}
