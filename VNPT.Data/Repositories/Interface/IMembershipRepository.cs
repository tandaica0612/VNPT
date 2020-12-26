using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using VNPT.Data.DataTransferObject;

namespace VNPT.Data.Repositories
{
    public interface IMembershipRepository : IRepository<Membership>
    {
        public List<MembershipDataTransfer> GetMembershipDataTransferByParentIDToList(int parentID);
        public Membership GetByPhoneAndPassword(string phone, string password);
        public bool IsLogin(string account, string password);
        public List<Membership> GetNotRevenueByYearAndMonthToList(int year, int month);
        public List<Membership> GetNotRevenueByYearAndMonthAndProductIDToList(int year, int month, int productID);
        public List<Membership> GetNotRevenueByYearAndMonthAndProductIDAndCityIDToList(int year, int month, int productID, int cityID);
        public Membership GetByTaxCode(string taxCode);
        public List<Membership> GetByCityIDToList(int cityID);
        public List<Membership> GetByProductIDAndCityIDAndActionToList(int productID, int cityID, int action);
        public List<Membership> GetByProductIDNotAndCityIDAndActionToList(int productID, int cityID, int action);
        public string UploadInvoiceByYearAndMonth(int requestUserID, int year, int month, string taxCode, string paymentCode, string productCode, string productName, string groupName, string code, decimal valueContract);
        public List<Membership> GetParentIDAndSeachStringToList(int parentID, string searchString);
        public List<MembershipDataTransfer> GetSQLByParentIDToList(int parentID);
        public List<MembershipDataTransfer> GetSQLMembershipDataTransferByParentID001ToList(int parentID);
        public List<Membership> GetByThanhVienToList();
        public List<Membership> GetParentIDAndCityIDAndWardIDToList(int parentID, int cityID, int wardID);
        public List<Membership> GetParentIDAndCityIDAndWardIDAndProductIDAndSearchStringToList(int parentID, int cityID, int wardID, int productID, string searchString);

    }
}
