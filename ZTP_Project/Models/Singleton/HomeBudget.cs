using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;
using ZTP_Project.TemplateMethod;
namespace ZTP_Project.Models.Singleton
{
    public class HomeBudget
    {
        private static HomeBudget _instance;

        public List<Transaction> Transactions { get; private set; }

        public Dictionary<string, double> MonthlyExpenseLimits { get; private set; } //kategoria, limit

        public List<SavingsGoal> SavingsGoals { get; private set; }

        public static HomeBudget GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HomeBudget();
            }
            return _instance;
        }

        private HomeBudget()
        {
            Transactions = new List<Transaction>();
            MonthlyExpenseLimits = new Dictionary<string, double>();
            SavingsGoals = new List<SavingsGoal>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Transactions.Remove(transaction);
        }

        public void SetSavingsGoal(SavingsGoal savingsGoal)
        {
            var existingGoal = SavingsGoals.Find(x => x.Name == savingsGoal.Name);
            if (existingGoal != null)
            {
                existingGoal.Amount = savingsGoal.Amount;
                return;
            }
            SavingsGoals.Add(savingsGoal);
        }

        public void RemoveSavingsGoal(SavingsGoal savingsGoal)
        {
            SavingsGoals.Remove(savingsGoal);
        }

        public void SetMonthlyExpenseLimit(string category, double limit) 
        {
            MonthlyExpenseLimits[category] = limit;
        }

        public bool Save(string path, string type)
        {
            Exporter exporter;

            switch(type)
            {
                case "csv":
                    exporter = new ExporterCSV();
                    break;
                case "txt":
                    exporter = new ExporterTXT();
                    break;
                default:
                    throw new ArgumentException("Unsupported file type");
            }
            try
            {
                exporter.Save(path, Transactions);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }



        public double GetTotalAmount()
        {
            double totalAmount = 0;
            foreach (Transaction transaction in Transactions)
            {
                if(transaction.Type == "Expense")
                    totalAmount -= transaction.Amount;
                else
                    totalAmount += transaction.Amount;
            }
            return totalAmount;
        }
    }
}
