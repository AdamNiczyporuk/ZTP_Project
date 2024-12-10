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
            Console.Clear();
            DisplayHomeBudgetWriting();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose [green]option[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {"Add Expense", "Add Income","Manage Limits", "Manage Savings Goals", "Generate Report", "Check Expense Prognosis", "Export Data"}));
            return option;
        }
        private void DisplayHomeBudgetWriting()
        {
            AnsiConsole.Write(new FigletText("Home Budget").Color(Color.Green).Centered());
            AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("Green")));
        }
    }
}
