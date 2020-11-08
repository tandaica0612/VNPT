using VNPT.Data.DataTransferObject;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace VNPT.Data.Repositories
{
    public class InvoicePropertyRepository : Repository<InvoiceProperty>, IInvoicePropertyRepository
    {
        private readonly VNPTContext _context;

        public InvoicePropertyRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public InvoiceProperty GetByInvoiceIDAndProductID(int invoiceID, int productID)
        {
            InvoiceProperty item = _context.Set<InvoiceProperty>().FirstOrDefault(item => item.InvoiceID == invoiceID && item.ProductID == productID);
            return item;
        }
        public List<InvoicePropertyDataTransfer> GetDataTransferProductByMembershipIDAndYearAndMonthToList(int membershipID, int year, int month)
        {
            List<InvoicePropertyDataTransfer> list = new List<InvoicePropertyDataTransfer>();
            if ((membershipID > 0) && (year > 0) && (month > 0))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@MembershipID",membershipID),
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_InvoicePropertySelectDataTransferByMembershipIDAndYearAndMonth", parameters);
                list = SQLHelper.ToList<InvoicePropertyDataTransfer>(dt);
            }
            return list;
        }
    }
}
