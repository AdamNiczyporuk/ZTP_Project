﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP_Project.Views
{
    public class MainView
    {
        public string DisplayMainMenu()
        {
            ClearScreen();
            DisplayHomeBudgetWriting();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [green]option[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {"Add Expense", "Add Income","Manage Limits", "Manage Savings Goals", "Generate Report", "Check Expense Prognosis", "Export Data",
                "Exit"}));
            return option;
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
        private void DisplayHomeBudgetWriting()
        {
            AnsiConsole.Write(new FigletText("Home Budget").Color(Color.Green).Centered());
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("Green")));
        }
        public string GetTransactionName()
        {
            return AnsiConsole.Ask<string>("What is the transaction name?");
        }
        public string GetTransactionAmount()
        {
            return AnsiConsole.Ask<string>("What is the transaction amount?");
        }
        public string GetTransactionDate()
        {
            return AnsiConsole.Ask<string>("When was the transaction made(yyyy-MM-dd HH:mm)?");
        }
        public string GetTransactionCategory()
        {
            return AnsiConsole.Ask<string>("What is the transaction category?");
        }
        public void ErrorMessage(string message)
        {
            AnsiConsole.MarkupLine($"[red]{message}[/]");
        }

        public string GetCategoryOfExpenseLimit()
        {
            return AnsiConsole.Ask<string>("What is the category of Expense Limit?");
        }

        public string GetExpenseLimit()
        {
            return AnsiConsole.Ask<string>("What is the expense limit?");
        }

        public string GetSavingGoalName()
        {
            return AnsiConsole.Ask<string>("What is the name of the saving goal?");
        }
        public string GetSavingGoalAmount()
        {
            return AnsiConsole.Ask<string>("What is the amount of the saving goal?");
        }

        public string GetTypeOfExportedData()
        {
            return AnsiConsole.Ask<string>("In what type you would like to export Transactions");
        }

        public string GetPath()
        {
            return AnsiConsole.Ask<string>("What is the path to the file?");
        }
        public void DisplayExpenseLimits(Dictionary<string, double> monthlyExpenseLimits, List<double> currentValues)
        {
            var barChart = new BarChart()
                .Width(60)
                .Label("[green bold]Monthly Expense Limits[/]")
                .CenterLabel();
            barChart.MaxValue = 100;
            int index = 0;
            foreach (var limit in monthlyExpenseLimits)
            {
                double currentValue = currentValues[index];
                double percentage = (currentValue / limit.Value) * 100;

                if (currentValue < limit.Value)
                {
                    barChart.AddItem($"{limit.Key}    [green]open![/]", (int)percentage, Color.Green);
                }
                else
                {
                    barChart.AddItem($"{limit.Key} [red]reached![/]", 100, Color.Red);
                }

                index++;
            }

            AnsiConsole.Write(barChart);
        }
        public string ManageExpenseLimits()
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [green]option[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] { "Set Monthly Expense Limit", "Remove Monthly Expense Limit", "Back" }));
        }
        public string ChooseLimitWithNewOption(Dictionary<string, double> limits)
        {
            var categories = limits.Keys.ToList();
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [green]option[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices("Create new limit")
                .AddChoices(categories));
        }
        public string ChooseLimit(Dictionary<string, double> limits)
        {
            var categories = limits.Keys.ToList();
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [green]option[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(categories));
        }
    }
}
