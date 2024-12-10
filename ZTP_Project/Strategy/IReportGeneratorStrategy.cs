using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Singleton;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace ZTP_Project.Strategy
{
    public interface IReportGeneratorStrategy
    {
        IRenderable GenerateReport(HomeBudget homeBudget, DateTime startDate, DateTime endDate);
    }
}
