using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Models;

namespace VNPT.CRM.Models
{
    public class BaseViewModel
    {
        public int ID { get; set; }
        public int YearFinance { get; set; }
        public int MonthFinance { get; set; }

        public Membership Membership { get; set; }

    }
}
