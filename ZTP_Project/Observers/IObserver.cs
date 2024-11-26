using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Observers
{
    public interface IObserver
    {
        void Powiadom(string wiadomosc);
    }
}
