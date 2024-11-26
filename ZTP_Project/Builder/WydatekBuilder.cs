using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Builder
{
    public class WydatekBuilder
    {
        private string _nazwa;
        private decimal _kwota;
        private string _kategoria;
        private DateTime _data;

        public WydatekBuilder SetNazwa(string nazwa)
        {
            _nazwa = nazwa;
            return this;
        }

        public WydatekBuilder SetKwota(decimal kwota)
        {
            _kwota = kwota;
            return this;
        }

        public WydatekBuilder SetKategoria(string kategoria)
        {
            _kategoria = kategoria;
            return this;
        }
        
        public WydatekBuilder SetData(DateTime data)
        {
            _data = data;
            return this;
        }

        public Wydatek Build()
        {
            return new Wydatek(_nazwa, _kwota, _kategoria,_data);
        }
        
    }
}
