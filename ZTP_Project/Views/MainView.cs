using Spectre.Console;
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
            return AnsiConsole.Ask<string>("What is the category?");
        }

        public string GetExpenseLimit()
        {
            return AnsiConsole.Ask<string>("What is the expense limit?");
        }


    }
}
