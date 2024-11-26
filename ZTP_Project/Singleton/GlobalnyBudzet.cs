using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Singleton
{
    public sealed class GlobalnyBudzet
    {
        private static GlobalnyBudzet _instance;

        public Budzet Budzet { get; private set; }

        private GlobalnyBudzet()
        {
            Budzet = new Budzet();
        }

        public static GlobalnyBudzet GetInstance()
        {
            if (_instance == null)
                _instance = new GlobalnyBudzet();

            return _instance;
        }
    }
}
