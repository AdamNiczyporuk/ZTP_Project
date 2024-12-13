using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;


namespace ZTP_Project.Views
{
    public class ReportView
    {
        private IRenderable report; 
        public ReportView(IRenderable report)
        {
            this.report = report;
        }

        public void DisplayReport()
        {
          AnsiConsole.Render(report);
        }
        private void DisplayTransactions(List<Transaction> transactions)
        {
            var table = new Table();
            table.AddColumn("Name");
            table.AddColumn("Category");
            table.AddColumn("Amount");
            table.AddColumn("Date");


            foreach (var transaction in transactions)
            {
                table.AddRow(
                    transaction.Name,
                    transaction.Category,
                    transaction.Amount.ToString("C"),
                    transaction.Date.ToString("yyyy-MM-dd HH:mm")

                );
            }

            AnsiConsole.Render(table);
        }
    }
}
