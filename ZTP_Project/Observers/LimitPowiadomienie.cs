using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Observers
{
    public class LimitPowiadomienie
    {
        public void Powiadom(decimal suma, decimal limit)
        {
            if (suma > limit)
            {
                Console.WriteLine($"Uwaga! Przekroczono limit: {limit}");
            }
        }
    }
}
