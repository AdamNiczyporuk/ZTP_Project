using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorator
{
    public class MultiplayDecorator : PrognosisDecorator
    {
        private double skale;
        public MultiplayDecorator(IPrognosis prognosis, double skale) : base(prognosis)
        {
            this.skale = skale;
        }

        public override double GeneratePrognosis(List<Transaction> transactions)
        {
            return base.GeneratePrognosis(transactions) * skale;
        }
    }
}
