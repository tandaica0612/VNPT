using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IInvoicePropertyRepository : IRepository<InvoiceProperty>
    {
        public InvoiceProperty GetByInvoiceIDAndProductID(int invoiceID, int productID);
        public List<InvoicePropertyDataTransfer> GetDataTransferProductByMembershipIDAndYearAndMonthToList(int membershipID, int year, int month);
    }
}
