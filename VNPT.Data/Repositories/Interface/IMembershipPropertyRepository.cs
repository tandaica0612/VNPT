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
        public List<MembershipPropertyDataTransfer> GetDataTransferProductByMembershipIDAndCodeToList(int membershipID, string code);
        public List<MembershipPropertyDataTransfer> GetDataTransferNhanVienByMembershipIDAndCodeToList(int membershipID, string code);
    }
}
