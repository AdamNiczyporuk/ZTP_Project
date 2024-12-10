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
            var root = new Tree("Root");
            return root;
        }
    }
   
}
