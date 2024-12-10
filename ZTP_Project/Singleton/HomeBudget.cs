using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;
namespace ZTP_Project.Singleton
{
    public class HomeBudget
    {
        private static HomeBudget _instance;

        private List<Transaction> Transactions { get; set; }

        private Dictionary<string,double> MonthlyExpenseLimit { get; set; }

        private List<SavingsGoal> SavingsGoals { get; set; }

        public HomeBudget GetInstance()
        {
            if(_instance == null)
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




    }
}
