using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorator
{
    public class Prognosis : IPrognosis
    {

        private DateOnly endDay;
        public double GeneratePrognosis(List<Transaction> transactions)
        {
            if (transactions.Count == 0)
            {
                throw new Exception("No transactions to generate prognosis");
            }
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            int daysBetween = (endDay.ToDateTime(TimeOnly.MinValue) - today.ToDateTime(TimeOnly.MinValue)).Days;
            if (daysBetween < 0)
            {
                throw new Exception("End day is before today");
            }
            double average = CalculateAverage(transactions);
            return average * daysBetween;
        }

        private double CalculateAverage(List<Transaction> transactions)
        {
            double sum = 0;
            foreach (Transaction transaction in transactions)
            {
                if(transaction.Type=="Expense")
                sum += transaction.Amount;
            }
            return sum / transactions.Count;
        }
    }
}
