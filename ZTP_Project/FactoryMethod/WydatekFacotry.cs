using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.FactoryMethod
{
    public static class WydatekFactory
    {
        public static Wydatek UtworzWydatek(string nazwa, decimal kwota, string kategoria)
        {
            return new Wydatek(nazwa, kwota, kategoria);
        }
    }
}
