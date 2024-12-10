using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models.Singleton;
using ZTP_Project.Strategy;
using ZTP_Project.Views;

namespace ZTP_Project.Controllers
{
    public class ReportController
    {
        private IReportGeneratorStrategy _reportStrategy;

        private ReportView _reportView;

        public ReportController(IReportGeneratorStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;

        }

        public void ShowReport(HomeBudget homeBudget,DateTime startdate, DateTime enddate)
        {
           
        }

    }

 }
