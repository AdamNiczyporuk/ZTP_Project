using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Models
{
    public  class SavingsGoal
    {
        public double Amount { get; set; }
        public bool isReached { get; set; }
        public string Name { get; set; }

        public SavingsGoal(double amount, string name)
        {
            Amount = amount;
            Name = name;
            isReached = false;
        }


    }
}
