﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTP_Project.Models;

namespace ZTP_Project.Decorator
{
    public interface IPrognosis
    {
        public double GeneratePrognosis(List<Transaction> transactions);
    }
}
