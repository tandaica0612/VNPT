using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class InvoicePropertyDataTransfer : InvoiceProperty
    {
        public string ProductName { get; set; }
        public string PaymentCode { get; set; }
        public string ProductCode { get; set; }
    }
}
