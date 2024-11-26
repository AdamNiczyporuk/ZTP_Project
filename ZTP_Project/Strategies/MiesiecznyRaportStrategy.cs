using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Strategies
{
    public class MiesiecznyRaportStrategy : IRaportStrategy
    {
        public string GenerujRaport(List<Wydatek> wydatki)
        {
            var raport = new StringBuilder();
            var wydatkiZaMiesiac = wydatki
                .Where(w => w.Data.Month == DateTime.Now.Month)
                .GroupBy(w => w.Kategoria)
                .Select(g => new { Kategoria = g.Key, Suma = g.Sum(w => w.Kwota) });

            raport.AppendLine("=== Miesięczny Raport ===");
            foreach (var wydatek in wydatkiZaMiesiac)
            {
                raport.AppendLine($"{wydatek.Kategoria}: {wydatek.Suma:C}");
            }

            return raport.ToString();
        }
    }

}
