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
    public interface IReportGeneratorStrategy
    {
        IRenderable GenerateReport(HomeBudget homeBudget, DateTime startDate, DateTime endDate);
    }
}
