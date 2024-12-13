using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

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
                .Label("[green bold]Monthly Expense Limits %[/]")
                .CenterLabel();
            barChart.MaxValue = 100;
            int index = 0;
            foreach (var limit in monthlyExpenseLimits)
            {
                double currentValue = currentValues[index];
                double percentage = (currentValue / limit.Value) * 100;

                if (currentValue < limit.Value)
                {
                    barChart.AddItem($"{limit.Key} [blue]{limit.Value}[/]  [green]open![/]", (int)percentage, Color.Green);
                }
                else
                {
                    barChart.AddItem($"{limit.Key} [blue]{limit.Value}[/] [red]reached![/]", 100, Color.Red);
                }

                index++;
            }

            AnsiConsole.Write(barChart);
        }
        public string ManageExpenseLimits()
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] { "Set Monthly Expense Limit", "Remove Monthly Expense Limit", "Back" }));
        }
        
        public string ChooseLimit(Dictionary<string, double> limits)
        {
            var categories = limits.Keys.ToList();
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [red]category[/] to remove")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(categories));
        }
        public void ShowMessage(string message)
        {
            AnsiConsole.MarkupLine($"[green]{message}[/]");
            Console.ReadKey();
        }
        public void DisplaySavingsGoals(List<SavingsGoal> savingsGoals, double amount)
        {
            var table = new Table();
            table.Border = TableBorder.Rounded;
            table.Title = new TableTitle("Savings Goals");
            table.AddColumn("Name");
            table.AddColumn("Amount");
            table.AddColumn("Status");
            table.AddColumns("Progress");
            table.Centered();
            foreach (var goal in savingsGoals)
            {
               var progress = ( amount / goal.Amount) * 100;

                table.AddRow(goal.Name, goal.Amount.ToString(), goal.isReached ? "[green]Reached[/]" : "[red]Not reached[/]",$"{progress}%");
            }
            AnsiConsole.Render(table);
        }
        public string ChooseSavingsGoal(List<SavingsGoal> savingsGoals)
        {
            List<string> categories = new List<string>();
            savingsGoals.ForEach(x => categories.Add(x.Name));
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [red]savings goal[/] to remove")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(categories));
        }
        public string ManageSavingsGoals()
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] { "Set Savings Goal", "Remove Savings Goal", "Back" }));
        }
        public List<string> GetPrognosisOption()
        {
            return  AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("Prognosis [green]options[/]?")
        .PageSize(10)
        .NotRequired()
        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
        .InstructionsText(
            "[grey](Press [blue]<space>[/] to choose option, " +
            "[green]<enter>[/] to accept)[/]")
        .AddChoices(new[] {
            "Define data range", "Plan to save more", "Plan bigger expenses"
            
        }));
        }
        public string GetDate(string message)
        {
            return AnsiConsole.Ask<string>($"{message}(yyyy-MM-dd)?");
        }
    }
    
}
