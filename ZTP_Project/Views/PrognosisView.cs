using Microsoft.VisualBasic;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Decorator;
using ZTP_Project.Models;
using ZTP_Project.Models.Singleton;

namespace ZTP_Project.Views
{
    public class PrognosisView
    {
        private IPrognosis prognosis;
        public PrognosisView(IPrognosis prognosis)
        {
            this.prognosis = prognosis;
        }
        public void DisplayPrognosis(DateOnly endDay, List<Transaction> transactions)
        {
           
            var amount = prognosis.GeneratePrognosis(transactions);
            AnsiConsole.Status()
            .Start("Generating Prognosis...", ctx =>
            {
        // Simulate some work
        AnsiConsole.MarkupLine("LOG: Fetching data...");
        Thread.Sleep(2000);

        AnsiConsole.MarkupLine("LOG: Analizing previous expenses...");
        Thread.Sleep(2000);

        // Update the status and spinner
        ctx.Status("Processing prognosis");
        ctx.Spinner(Spinner.Known.Star);
        ctx.SpinnerStyle(Style.Parse("green"));
        AnsiConsole.MarkupLine("LOG: Checking addidtional options...");
        Thread.Sleep(2000);
        // Simulate some work
        AnsiConsole.MarkupLine("LOG: Finishing...");
        Thread.Sleep(2000);
            });
            var panel = new Panel($"Your prognosis to {endDay.ToString()} is: [green]{amount.ToString("F2")}[/]zł")
                .Header("[green]Prognosis[/]");
            AnsiConsole.Render(panel);
        }
       
        

            
    }
}
