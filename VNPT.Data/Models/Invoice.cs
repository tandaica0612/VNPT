using VNPT.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VNPT.Data.Models
{
    public partial class Invoice : BaseModel
    {

        public int? ContractID { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public decimal? Total { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DateInvoice { get; set; }
    }
}
