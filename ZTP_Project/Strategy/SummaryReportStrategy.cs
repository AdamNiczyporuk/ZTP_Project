using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Rendering;
using ZTP_Project.Models.Singleton;

namespace ZTP_Project.Strategy
{
    public  class SummaryReportStrategy : IReportGeneratorStrategy
    {
        public IRenderable GenerateReport(HomeBudget homeBudget, DateTime startDate, DateTime endDate)
        {
            //var transactions = homeBudget.Transactions.Where(t => t.Date >= startDate && t.Date <= endDate).ToList();

            var root = new Tree("Root");
            return root;
        }
    } 
}
