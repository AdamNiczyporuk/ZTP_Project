using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;
namespace ZTP_Project.Models.Singleton
{
    public class HomeBudget
    {
        private static HomeBudget _instance;

        private List<Transaction> Transactions { get; set; }

        private Dictionary<string, double> MonthlyExpenseLimit { get; set; } //kategoria, limit

        private List<SavingsGoal> SavingsGoals { get; set; }

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
            MonthlyExpenseLimit = new Dictionary<string, double>();
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
            SavingsGoals.Add(savingsGoal);
        }

        public void RemoveSavingsGoal(SavingsGoal savingsGoal)
        {
            SavingsGoals.Remove(savingsGoal);
        }

        public void SetMonthlyExpenseLimit(string category, double limit) 
        {
            MonthlyExpenseLimit[category] = limit;
        }

        public bool Save(string path, string type)
        {
            return true;
        }




    }
}
