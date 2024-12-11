using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.TemplateMethod
{
    internal class ExporterCSV : Exporter
    {

        protected override StreamWriter OpenFile(string path)
        {
            path += ".csv";
            return new StreamWriter(path);
        }


        protected override void InsertData(StreamWriter sw, List<Transaction> transactions)
        {
            sw.WriteLine("Amount;Date;Name;Category;Type");
            foreach (var t in transactions)
            {
                string formattedDate = t.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                sw.WriteLine($"{t.Amount};{formattedDate};{t.Name};{t.Category};{t.Type}");
            }
        }



    }
}
