using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Models
{
    public class Transaction
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string Type { get; set; }

        public Transaction(double amount, DateTime date, string name, string category, string type)
        {
            Amount = amount;
            Date = date;
            Name = name;
            Category = category;
            Type = type;
        }
    }
}
