using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IMembershipPropertyRepository : IRepository<MembershipProperty>
    {
        public MembershipProperty GetByMembershipIDAndPaymentCodeAndProductCode(int membershipID, string paymentCode, string productCode);
        public List<MembershipPropertyDataTransfer> GetDataTransferProductByMembershipIDToList(int membershipID);
    }
}
