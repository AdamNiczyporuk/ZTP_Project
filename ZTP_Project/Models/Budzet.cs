using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Models
{
    public class Budzet
    {
        public decimal Przychody { get; set; }
        public decimal Limit { get; set; }
        public List<Wydatek> Wydatki { get; set; } = new List<Wydatek>();

        public void DodajWydatek(Wydatek wydatek)
        {
            Wydatki.Add(wydatek);
        }
    }
}
