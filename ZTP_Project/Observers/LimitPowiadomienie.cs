using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Observers
{
    public class LimitPowiadomienie : IObserver
    {
        public void Powiadom(string wiadomosc)
        {
            Console.WriteLine($"[POWIADOMIENIE]: {wiadomosc}");
        }
    }
}
