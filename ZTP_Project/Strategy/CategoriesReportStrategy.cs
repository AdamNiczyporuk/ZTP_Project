using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models.Singleton;

namespace ZTP_Project.Strategy
{
    public class CategoriesReportStrategy : IReportGeneratorStrategy
    {
        public IRenderable GenerateReport(HomeBudget homeBudget, DateTime startDate, DateTime endDate)
        {
            var tranzactions = homeBudget.GetTransactions(startDate, endDate);
            Dictionary<string, double> categorieWithAmounts = new Dictionary<string, double>();

            foreach (var tranzaction in tranzactions)
            {
                if (categorieWithAmounts.ContainsKey(tranzaction.Category))
                {
                    categorieWithAmounts[tranzaction.Category] += tranzaction.Amount;
                }
                else
                {
                    categorieWithAmounts.Add(tranzaction.Category, tranzaction.Amount);
                }
            }
            var breakdownChart = new BreakdownChart()
            .Width(70);
            var colors = new List<Color>
            {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Yellow,
                Color.Purple,
                Color.Cyan1,
                Color.Orange1,
                Color.Pink1,
                Color.RosyBrown,
                Color.Grey

            };
            int colorIndex = 0;
            foreach (var item in categorieWithAmounts)
            {
                var color = colors[colorIndex%colors.Count];
                breakdownChart.AddItem(item.Key, item.Value,color);
                colorIndex++;
            }




            return breakdownChart;
        }
    }

}
