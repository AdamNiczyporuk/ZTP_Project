using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorator
{
    public class PrognosisDecorator : IPrognosis
    {
        protected IPrognosis prognosis;
        public PrognosisDecorator(IPrognosis prognosis)
        {
            this.prognosis = prognosis;
        }

        public virtual double GeneratePrognosis(List<Transaction> transactions)
        {
            return prognosis.GeneratePrognosis(transactions);
        }
    }
}
