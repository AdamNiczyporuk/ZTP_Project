using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Rendering;
using ZTP_Project.Models;
using ZTP_Project.Models.Singleton;

namespace ZTP_Project.Strategy
{
    public  class SummaryReportStrategy : IReportGeneratorStrategy
    {
        public IRenderable GenerateReport(HomeBudget homeBudget, DateTime startDate, DateTime endDate)
        {
            var tranzactions = homeBudget.GetTransactions(startDate, endDate);
            double incomes = 0;
            double expenses = 0;
            foreach (var tranzaction in tranzactions)
            {
                if (tranzaction.Type == "Income")
                {
                    incomes += tranzaction.Amount;
                }
                else
                {
                    expenses += tranzaction.Amount;
                }
            }
            var breakdownChart = new BreakdownChart()
            .Width(70)
            .AddItem("Incomes", incomes, Color.Green)
            .AddItem("Expenses", expenses, Color.Red3);
    

           
            return breakdownChart;
        }
       
    }
    
}
