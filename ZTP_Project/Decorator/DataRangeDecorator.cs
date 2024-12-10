using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorator
{
    public class DataRangeDecorator : PrognosisDecorator
    {
        private DateOnly dateFrom;
        private DateOnly dateTo;
        public DataRangeDecorator(IPrognosis prognosis, DateOnly dateFrom, DateOnly dateTo) : base(prognosis)
        {
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
        }

        public override double GeneratePrognosis(List<Transaction> transactions)
        {
            List<Transaction> transactionsInRange = transactions.FindAll(transaction => DateOnly.FromDateTime(transaction.Date) >= dateFrom &&
                                                                        DateOnly.FromDateTime(transaction.Date) <= dateTo);

            return base.GeneratePrognosis(transactions);
        }
    }
    
    
}
