﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models.Singleton;
using ZTP_Project.Views;
using ZTP_Project.Models;
using System.ComponentModel;
using Spectre.Console;
using ZTP_Project.Decorator;
using ZTP_Project.Strategy;
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
            homeBudget.SetMonthlyExpenseLimit("Utilities", 200);
        }
        public void StartMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                string option = mainView.DisplayMainMenu();
                switch (option)
                {
                    case "Add Expense":
                        AddExpense();
                        break;
                    case "Add Income":
                        AddIncome();
                        break;
                    case "Manage Limits":
                        ManageExpenseLimits();
                        break;
                    case "Manage Savings Goals":
                        ManageSavingGoals();
                        break;
                    case "Generate Report":
                        GenerateReport();
                        break;
                    case "Check Expense Prognosis":
                        CheckExpensePrognosis();
                        break;
                    case "Export Data":
                        ExportData();
                        break;
                    case "Exit":
                        exit = true;

                        break;
                }
            }
        }
        private void GenerateReport()
        {
            DateTime parsedStartDate = DateTime.MinValue;
            DateTime parsedEndDate  =DateTime.MaxValue; ;
            var option1 = mainView.GetReportType();
            switch (option1)
            {
                case "Summary":
                    parsedEndDate = DateTime.MaxValue;
                    parsedStartDate = DateTime.MinValue;
                    break;
                case "Annual":
                    GetYearForAnnualReport(out parsedStartDate, out parsedEndDate);
                    break;
                case "Monthly":
                    GetMonthForMonthlyReport(out parsedStartDate, out parsedEndDate);
                    break;
                case "Custom":
                    GetDatesForCustomReport(out parsedStartDate, out parsedEndDate);
                    break;
            }

            bool divisionIntoCategories = false;

            var options = mainView.GetReportOption();
            foreach (var option in options)
            {
                switch (option)
                {
                    
                    case "Division into categories":
                        divisionIntoCategories = true;

                        break;
                }
            }
            if(divisionIntoCategories)
            {
               var reportController = new ReportController(new CategoriesReportStrategy());
                reportController.ShowReport(homeBudget, parsedStartDate, parsedEndDate);
            }
            else
            {
                var reportController = new ReportController(new SummaryReportStrategy());
                reportController.ShowReport(homeBudget, parsedStartDate, parsedEndDate);
            }
        }
        public void GetYearForAnnualReport(out DateTime parsedStartDate, out DateTime parsedEndDate)
        {

            while (true)
            {
                string year = mainView.GetYear();
                if (int.TryParse(year, out int yearInt) && yearInt >= 1900 && yearInt <= 2300)
                {
                    parsedStartDate = new DateTime(yearInt, 1, 1);
                    parsedEndDate = parsedStartDate.AddYears(1).AddDays(-1);
                    break;
                }
                else
                {
                    mainView.ErrorMessage("Year must be an integer between 1900 and 2300.");
                }
            }
            parsedEndDate = parsedStartDate.AddYears(1).AddDays(-1);
        }
        public void GetDatesForCustomReport(out DateTime parsedStartDate, out DateTime parsedEndDate)
        {
            while (true)
            {
                string startDate = mainView.GetDate("Provide the start date");
                if (!DateTime.TryParseExact(startDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedStartDate))
                {
                    mainView.ErrorMessage("Start date must be in the format yyyy-MM-dd.");
                }
                else
                {
                    break;
                }
            }

            // Validate end date
            while (true)
            {
                string endDate = mainView.GetDate("Provide the end date");
                if (!DateTime.TryParseExact(endDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedEndDate))
                {
                    mainView.ErrorMessage("End date must be in the format yyyy-MM-dd.");
                }
                else if (parsedEndDate < parsedStartDate)
                {
                    mainView.ErrorMessage("End date must be after the start date.");
                }
                else
                {
                    break;
                }
            }

        }
        public void GetMonthForMonthlyReport(out DateTime parsedStartDate, out DateTime parsedEndDate)
        {
            int yearInt;
            int monthInt;

            // Validate year
            while (true)
            {
                string year = mainView.GetYear();
                if (int.TryParse(year, out yearInt) && yearInt >= 1900 && yearInt <= 2300)
                {
                    break;
                }
                else
                {
                    mainView.ErrorMessage("Year must be an integer between 1900 and 2300.");
                }
            }

            // Validate month
            while (true)
            {
                string month = mainView.GetMonth();
                if (int.TryParse(month, out monthInt) && monthInt >= 1 && monthInt <= 12)
                {
                    break;
                }
                else
                {
                    mainView.ErrorMessage("Month must be an integer between 1 and 12.");
                }
            }

            parsedStartDate = new DateTime(yearInt, monthInt, 1);
            parsedEndDate = parsedStartDate.AddMonths(1).AddDays(-1);
        }
        private void AddExpense()
        {
            AddTransaction("Expense");
        }
        private void AddIncome()
        {
            AddTransaction("Income");
        }
        private void AddTransaction(string type)
        {
            if (type != "Expense" && type != "Income")
            {
                throw new ArgumentException("Transaction Type must be either Expense or Income");
            }
            string name;
            double parsedAmount;
            DateTime parsedDate;
            string category;

            // Validate name
            while (true)
            {
                name = mainView.GetTransactionName();
                if (string.IsNullOrWhiteSpace(name))
                {
                    mainView.ErrorMessage("Name must be provided.");
                }
                else
                {
                    break;
                }
            }

            // Validate amount
            while (true)
            {
                string amount = mainView.GetTransactionAmount();
                if (!double.TryParse(amount, out parsedAmount) || Math.Round(parsedAmount, 2) != parsedAmount)
                {
                    mainView.ErrorMessage("Amount must be a real number with up to 2 decimal places.");
                }
                else
                {
                    break;
                }
            }

            // Validate date
            while (true)
            {
                string date = mainView.GetTransactionDate();
                if (!DateTime.TryParseExact(date, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    mainView.ErrorMessage("Date must be in the format yyyy-MM-dd HH:mm.");
                }
                else
                {
                    break;
                }
            }

            // Validate category
            while (true)
            {
                category = mainView.GetTransactionCategory();
                if (string.IsNullOrWhiteSpace(category))
                {
                    mainView.ErrorMessage("Category must be provided.");
                }
                else
                {
                    break;
                }
            }


            Transaction transaction = new Transaction(parsedAmount, parsedDate, name, category, type);
            homeBudget.AddTransaction(transaction);
        }
        private void AddMonthlyExpenseLimit()
        {
            mainView.ClearScreen();
            string category;
            double parsedLimit;
            while (true)
            {
                category = mainView.GetCategoryOfExpenseLimit();

                if (string.IsNullOrWhiteSpace(category))
                {
                    mainView.ErrorMessage("Category must be provided.");
                }
                else
                {
                    break;
                }


            }


            while (true)
            {
                string limit = mainView.GetExpenseLimit();
                if (!double.TryParse(limit, out parsedLimit) || Math.Round(parsedLimit, 2) != parsedLimit)
                {
                    mainView.ErrorMessage("Limit must be a real number with up to 2 decimal places.");
                }
                else
                {
                    break;
                }
            }
            homeBudget.SetMonthlyExpenseLimit(category, parsedLimit);


        }
        private void AddSavingGoal()
        {
            double parsedAmount;
            string name;
            while (true)
            {
                name = mainView.GetSavingGoalName();
                if (string.IsNullOrWhiteSpace(name))
                {
                    mainView.ErrorMessage("Name must be provided.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                string amount = mainView.GetSavingGoalAmount();
                if (!double.TryParse(amount, out parsedAmount) || Math.Round(parsedAmount, 2) != parsedAmount)
                {
                    mainView.ErrorMessage("Amount must be a real number with up to 2 decimal places.");
                }
                else
                {
                    break;
                }
            }
            SavingsGoal savingsGoal = new SavingsGoal(parsedAmount, name);
            homeBudget.SetSavingsGoal(savingsGoal);
        }
        private void ExportData()
        {
            string type;
            string path;

            while (true)
            {
                type = mainView.GetTypeOfExportedData();
                if (string.IsNullOrWhiteSpace(type))
                {
                    mainView.ErrorMessage("Type must be provided.");
                }
                else if (type != "csv" && type != "txt")
                {
                    mainView.ErrorMessage("Type must be either csv or txt.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                path = mainView.GetPath();
                if (string.IsNullOrWhiteSpace(path))
                {
                    mainView.ErrorMessage("Path must be provided.");
                }
                else
                {
                    break;
                }
            }

            homeBudget.Save(path, type);


        }
        private void ManageExpenseLimits()
        {
            while (true)
            {

                var transactions = homeBudget.Transactions;
                var monthlyExpenseLimits = homeBudget.MonthlyExpenseLimits;
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;
                var currentValues = new List<double>();
                foreach (var limit in monthlyExpenseLimits)
                {
                    var category = limit.Key;

                    var currentMonthValue = transactions.Where(t => t.Category == category && t.Date.Month == currentMonth && t.Date.Year == currentYear).Sum(t => t.Amount);
                    currentValues.Add(currentMonthValue);
                }
                mainView.ClearScreen();
                mainView.DisplayExpenseLimits(monthlyExpenseLimits, currentValues);
                var option = mainView.ManageExpenseLimits();

                switch (option)
                {
                    case "Set Monthly Expense Limit":
                        AddMonthlyExpenseLimit();
                        break;
                    case "Remove Monthly Expense Limit":
                        RemoveMonthlyExpenseLimit();
                        break;
                    case "Back":
                        return;

                }
            }
        }
        private void RemoveMonthlyExpenseLimit()
        {
            var category = mainView.ChooseLimit(homeBudget.MonthlyExpenseLimits);
            mainView.ClearScreen();
            homeBudget.MonthlyExpenseLimits.Remove(category);
            mainView.ShowMessage("Monthly Expense Limit removed successfully");
            return;

        }
        private void ManageSavingGoals()
        {
            while (true)
            {
                mainView.ClearScreen();
                var savingsGoals = homeBudget.SavingsGoals;
                var amount = homeBudget.GetTotalAmount();
                foreach (var goal in savingsGoals)
                {
                    if (goal.Amount <= amount)
                    {
                        goal.isReached = true;
                    }
                    else
                    {
                        goal.isReached = false;
                    }
                }
                mainView.DisplaySavingsGoals(savingsGoals, amount);
                var option = mainView.ManageSavingsGoals();

                switch (option)
                {
                    case "Set Savings Goal":
                        AddSavingGoal();
                        break;
                    case "Remove Savings Goal":
                        RemoveSavingGoal();
                        break;
                    case "Back":
                        return;

                }
            }

        }
        private void RemoveSavingGoal()
        {
            var savingsGoal = mainView.ChooseSavingsGoal(homeBudget.SavingsGoals);
            mainView.ClearScreen();
            homeBudget.SavingsGoals.RemoveAll(x => x.Name == savingsGoal);
            mainView.ShowMessage("Savings Goal removed successfully");
            return;

        }

        private void CheckExpensePrognosis()
        {
            
            DateTime parsedDate;
            // Validate date
            while (true)
            {
                string date = mainView.GetDate("Provide final day of prognosis");
                if (!DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    mainView.ErrorMessage("Date must be in the format yyyy-MM-dd");
                }
                else
                {
                    break;
                }
            }
            DateOnly endDate = DateOnly.FromDateTime(parsedDate);

            IPrognosis prognosis = new Prognosis(endDate);
            var options = mainView.GetPrognosisOption();
            foreach (var option in options)
            {
                switch (option)
                {
                    case "Define data range":
                        prognosis= DefineDataRange(prognosis);
                        break;
                    case "Plan to save more":
                        prognosis = new MultiplayDecorator(prognosis, 0.8);
                        break;
                    case "Plan bigger expenses":
                        prognosis = new MultiplayDecorator(prognosis, 1.2);
                        break;
                }
            }
            try
            {
               mainView.ClearScreen();
               var prognosisView = new PrognosisView(prognosis);
               prognosisView.DisplayPrognosis(endDate,homeBudget.Transactions);
               mainView.ShowMessage("Prognosis generated successfully press any key to return");

            }
            catch (Exception e)
            {
                mainView.ErrorMessage(e.Message);
            }

        }
        private IPrognosis DefineDataRange(IPrognosis prognosis)
        {
            DateTime parsedStartDate;
            DateTime parsedEndDate;
            // Validate date
            while (true)
            {
                string startDate = mainView.GetDate("Provide date [blue]from[/] witch we should take tranzactions to analisis");
                if (!DateTime.TryParseExact(startDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedStartDate))
                {
                    mainView.ErrorMessage("Date must be in the format yyyy-MM-dd");
                }
                else
                {
                    break;
                }
            }
            // Validate date
            while (true)
            {
                string endDate = mainView.GetDate("Provide date [yellow]to[/] witch we should take tranzactions to analisis");
                if (!DateTime.TryParseExact(endDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedEndDate))
                {
                    mainView.ErrorMessage("Date must be in the format yyyy-MM-dd");
                }
                else
                {
                    break;
                }
            }
            DateOnly startDay = DateOnly.FromDateTime(parsedStartDate);
            DateOnly endDay = DateOnly.FromDateTime(parsedEndDate);
            
            return new DataRangeDecorator(prognosis,startDay,endDay);
        }
    }
}