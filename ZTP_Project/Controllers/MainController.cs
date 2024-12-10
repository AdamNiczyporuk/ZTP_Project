using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models.Singleton;
using ZTP_Project.Views;
using ZTP_Project.Models;
namespace ZTP_Project.Controllers
{
    public class MainController
    {
        private HomeBudget homeBudget;
        private MainView mainView;
        public MainController()
        {
            homeBudget = HomeBudget.GetInstance();
            mainView = new MainView();
            SeedData();//do celów testowych
        }
        private void SeedData()
        {
            List<Transaction> sampleTransactions = new List<Transaction>
            {
                new Transaction(1000, DateTime.Now.AddDays(-10), "Salary", "Income", "Income"),
                new Transaction(200, DateTime.Now.AddDays(-8), "Groceries", "Food", "Expense"),
                new Transaction(150, DateTime.Now.AddDays(-6), "Electricity Bill", "Utilities", "Expense"),
                new Transaction(50, DateTime.Now.AddDays(-4), "Internet Bill", "Utilities", "Expense"),
                new Transaction(300, DateTime.Now.AddDays(-2), "Freelance Work", "Income", "Income"),
                new Transaction(100, DateTime.Now.AddDays(-1), "Dining Out", "Food", "Expense")
            };
            var SavingsGoal = new SavingsGoal(1000, "New phone");
            homeBudget.SetSavingsGoal(SavingsGoal);
            foreach (var transaction in sampleTransactions)
            {
                homeBudget.AddTransaction(transaction);
            }
            homeBudget.SetMonthlyExpenseLimit("Food", 1000);
        }
        public void StartMainMenu()
        {
            string option = mainView.DisplayMainMenu();
            switch (option)
            {
                case "Add Expense":
                    // Add logic for adding expense
                    break;
                case "Add Income":
                    // Add logic for adding income
                    break;
                case "Manage Limits":
                    // Add logic for managing limits
                    break;
                case "Manage Savings Goals":
                    // Add logic for managing savings goals
                    break;
                case "Generate Report":
                    // Add logic for generating report
                    break;
                case "Check Expense Prognosis":
                    // Add logic for checking expense prognosis
                    break;
                case "Export Data":
                    // Add logic for exporting data
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}