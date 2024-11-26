using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.FactoryMethod
{
    public interface IWydatekFactory
    {
        Wydatek UtworzWydatek(string nazwa, decimal kwota, string kategoria, DateTime dateTime);
    }
    public class WydatekFactory : IWydatekFactory
    {
        public Wydatek UtworzWydatek(string nazwa, decimal kwota, string kategoria, DateTime dateTime)
        {
            return new Wydatek(nazwa, kwota, kategoria, dateTime);
        }
    }
}
