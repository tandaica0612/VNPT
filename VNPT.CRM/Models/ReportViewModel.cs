using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Models;

namespace VNPT.CRM.Models
{
    public class ReportViewModel
    {
        public int YearFinance { get; set; }
        public int MonthFinance { get; set; }
        public int MembershipIDCount { get; set; }
        public int MembershipIDPropertyCount { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal RevenueByYear { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal RevenueByYearAndMonth { get; set; }

    }
}
