using System;
using System.Collections.Generic;
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
            return new StreamWriter(path);
        }


        protected override void InsertData(StreamWriter sw, List<Transaction> transactions)
        {
            sw.WriteLine("Amout" + "," +"Date" + "," +"Name"+ "," + "Category" + "," +"Type");
            foreach (var t in transactions)
            {
                sw.WriteLine(t.Amount + "," + t.Date + "," + t.Name + "," + t.Category + "," + t.Type);
            }
        }

       
       
    }
}
