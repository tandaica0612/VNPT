using VNPT.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VNPT.Data.Models
{
    public partial class InvoiceProperty : BaseModel
    {
        public int? InvoiceID { get; set; }
        public int? ProductID { get; set; }
        public int? UnitID { get; set; }

        public decimal? Quantity { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal? UnitPrice { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public decimal? Total { get; set; }
    }
}
