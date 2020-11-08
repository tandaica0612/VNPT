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
    public class MembershipPropertyRepository : Repository<MembershipProperty>, IMembershipPropertyRepository
    {
        private readonly VNPTContext _context;

        public MembershipPropertyRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public MembershipProperty GetByMembershipIDAndPaymentCodeAndProductCode(int membershipID, string paymentCode, string productCode)
        {
            MembershipProperty item = _context.Set<MembershipProperty>().FirstOrDefault(item => item.MembershipID == membershipID && item.PaymentCode.Equals(paymentCode) && item.ProductCode.Equals(productCode));
            return item;
        }
        public List<MembershipPropertyDataTransfer> GetDataTransferProductByMembershipIDToList(int membershipID)
        {
            List<MembershipPropertyDataTransfer> list = new List<MembershipPropertyDataTransfer>();
            if (membershipID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@MembershipID",membershipID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipPropertySelectDataTransferProductByMembershipID", parameters);
                list = SQLHelper.ToList<MembershipPropertyDataTransfer>(dt);
            }
            return list;
        }
    }
}
