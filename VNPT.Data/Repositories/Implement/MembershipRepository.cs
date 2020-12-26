using VNPT.Data.Helpers;
using VNPT.Data.Models;
using VNPT.Data.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Data.SqlClient;
using System.Data;

namespace VNPT.Data.Repositories
{
    public class MembershipRepository : Repository<Membership>, IMembershipRepository
    {
        private readonly VNPTContext _context;

        public MembershipRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public bool IsLogin(string account, string password)
        {
            var membership = _context.Membership.FirstOrDefault(user => user.Phone.Equals(account));
            if (membership == null)
            {
                membership = _context.Membership.FirstOrDefault(user => user.Account.Equals(account));
            }
            if (membership == null)
            {
                membership = _context.Membership.FirstOrDefault(user => user.Email.Equals(account));
            }
            if (membership != null)
            {
                if (SecurityHelper.Decrypt(membership.GUICode, membership.Password).Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
        public Membership GetByPhoneAndPassword(string phone, string password)
        {
            bool check = false;
            var membership = _context.Membership.FirstOrDefault(user => user.Phone.Equals(phone));
            if (membership != null)
            {
                if (SecurityHelper.Decrypt(membership.GUICode, membership.Password).Equals(password))
                {
                    check = true;
                }
            }
            if (check == false)
            {
                membership = null;
            }
            return membership;
        }
        public Membership GetByTaxCode(string taxCode)
        {
            Membership item = _context.Set<Membership>().FirstOrDefault(item => item.TaxCode.Equals(taxCode));
            return item;
        }
        public List<Membership> GetByThanhVienToList()
        {
            List<Membership> list = new List<Membership>();
            list = _context.Set<Membership>().Where(item => item.ParentID != AppGlobal.DoanhNghiepID).OrderBy(item => item.FullName).ToList();
            return list;
        }
        public List<Membership> GetByCityIDToList(int cityID)
        {
            List<Membership> list = new List<Membership>();
            if (cityID > 0)
            {
                list = _context.Set<Membership>().Where(item => item.CityID == cityID).OrderBy(item => item.FullName).ToList();
            }
            return list;
        }
        public List<Membership> GetParentIDAndSeachStringToList(int parentID, string searchString)
        {
            List<Membership> list = new List<Membership>();
            if (parentID > 0)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Trim();
                    list = _context.Set<Membership>().Where(item => item.ParentID == parentID && ((item.TaxCode.Contains(searchString) == true) || (item.MembershipCode.Contains(searchString) == true) || (item.FullName.Contains(searchString) == true) || (item.Address.Contains(searchString) == true) || (item.ContactPhone.Contains(searchString) == true))).OrderBy(item => item.FullName).ToList();
                }
                else
                {
                    list = _context.Set<Membership>().Where(item => item.ParentID == parentID).OrderBy(item => item.FullName).ToList();
                }
            }
            return list;
        }
        public List<Membership> GetParentIDAndCityIDAndWardIDToList(int parentID, int cityID, int wardID)
        {
            List<Membership> list = new List<Membership>();
            if ((parentID > 0) && (cityID > 0) && (wardID > 0))
            {
                list = _context.Set<Membership>().Where(item => item.ParentID == parentID && item.CityID == cityID && item.WardID == wardID).OrderBy(item => item.FullName).ToList();
            }
            return list;
        }
        public List<Membership> GetParentIDAndCityIDAndWardIDAndProductIDAndSearchStringToList(int parentID, int cityID, int wardID, int productID, string searchString)
        {
            List<Membership> list = new List<Membership>();
            if (parentID > 0)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.Trim();
                    list = _context.Set<Membership>().Where(item => item.ParentID == parentID && ((item.TaxCode.Contains(searchString) == true) || (item.MembershipCode.Contains(searchString) == true) || (item.FullName.Contains(searchString) == true) || (item.Address.Contains(searchString) == true) || (item.ContactPhone.Contains(searchString) == true))).OrderBy(item => item.FullName).ToList();
                }
                else
                {
                    if (productID > 0)
                    {
                        if (wardID > 0)
                        {
                            list = GetByProductIDAndCityIDAndWardIDToList(productID, cityID, wardID);
                        }
                        else
                        {
                            list = GetByProductIDAndCityIDToList(productID, cityID);
                        }
                    }
                    else
                    {
                        if (wardID > 0)
                        {
                            list = _context.Set<Membership>().Where(item => item.ParentID == parentID && item.CityID == cityID && item.WardID == wardID).OrderBy(item => item.FullName).ToList();
                        }
                        else
                        {
                            list = _context.Set<Membership>().Where(item => item.ParentID == parentID && item.CityID == cityID).OrderBy(item => item.FullName).ToList();
                        }
                    }
                }
            }
            return list;
        }
        public List<MembershipDataTransfer> GetMembershipDataTransferByParentIDToList(int parentID)
        {
            List<MembershipDataTransfer> list = new List<MembershipDataTransfer>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ParentID",parentID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectMembershipDataTransferByParentID", parameters);
                list = SQLHelper.ToList<MembershipDataTransfer>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDToList(int productID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDNotToList(int productID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDNot", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDAndCityIDToList(int productID, int cityID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID),
                new SqlParameter("@CityID",cityID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDAndCityID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDAndCityIDAndWardIDToList(int productID, int cityID, int wardID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID),
                new SqlParameter("@CityID",cityID),
                new SqlParameter("@WardID",wardID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDAndCityIDAndWardID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetByProductIDNotAndCityIDToList(int productID, int cityID)
        {
            List<Membership> list = new List<Membership>();
            if (productID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ProductID",productID),
                new SqlParameter("@CityID",cityID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByProductIDNotAndCityID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public string UploadInvoiceByYearAndMonth(int requestUserID, int year, int month, string taxCode, string paymentCode, string productCode, string productName, string groupName, string code, decimal valueContract)
        {
            string result = "";
            if (!string.IsNullOrEmpty(taxCode))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@RequestUserID",requestUserID),
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@TaxCode",taxCode),
                new SqlParameter("@PaymentCode",paymentCode),
                new SqlParameter("@ProductCode",productCode),
                new SqlParameter("@ProductName",productName),
                new SqlParameter("@GroupName",groupName),
                new SqlParameter("@Code",code),
                new SqlParameter("@ValueContract",valueContract)
                };
                result = SQLHelper.ExecuteNonQueryAsync(AppGlobal.ConectionString, "sp_UploadInvoiceByYearAndMonth", parameters).Result;
            }
            return result;
        }
        public List<Membership> GetByProductIDAndCityIDAndActionToList(int productID, int cityID, int action)
        {
            List<Membership> list = new List<Membership>();
            switch (action)
            {
                case 0:
                    list = GetByProductIDToList(productID);
                    break;
                case 1:
                    list = GetByProductIDAndCityIDToList(productID, cityID);
                    break;
            }
            return list;
        }
        public List<Membership> GetByProductIDNotAndCityIDAndActionToList(int productID, int cityID, int action)
        {
            List<Membership> list = new List<Membership>();
            switch (action)
            {
                case 0:
                    list = GetByProductIDNotToList(productID);
                    break;
                case 1:
                    list = GetByProductIDNotAndCityIDToList(productID, cityID);
                    break;
            }
            return list;
        }
        public List<Membership> GetNotRevenueByYearAndMonthToList(int year, int month)
        {
            List<Membership> list = new List<Membership>();
            if ((year > 0) && (month > 0))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectNotRevenueByYearAndMonth", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }

        public List<Membership> GetNotRevenueByYearAndMonthAndProductIDToList(int year, int month, int productID)
        {
            List<Membership> list = new List<Membership>();
            if ((year > 0) && (month > 0) && (productID > 0))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@ProductID",productID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectNotRevenueByYearAndMonthAndProductID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<Membership> GetNotRevenueByYearAndMonthAndProductIDAndCityIDToList(int year, int month, int productID, int cityID)
        {
            List<Membership> list = new List<Membership>();
            if ((year > 0) && (month > 0) && (productID > 0) && (cityID > 0))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@ProductID",productID),
                new SqlParameter("@CityID",cityID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectNotRevenueByYearAndMonthAndProductIDAndCityID", parameters);
                list = SQLHelper.ToList<Membership>(dt);
            }
            return list;
        }
        public List<MembershipDataTransfer> GetSQLByParentIDToList(int parentID)
        {
            List<MembershipDataTransfer> list = new List<MembershipDataTransfer>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ParentID",parentID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectByParentID", parameters);
                list = SQLHelper.ToList<MembershipDataTransfer>(dt);
            }
            return list;
        }
        public List<MembershipDataTransfer> GetSQLMembershipDataTransferByParentID001ToList(int parentID)
        {
            List<MembershipDataTransfer> list = new List<MembershipDataTransfer>();
            if (parentID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ParentID",parentID)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_MembershipSelectMembershipDataTransferByParentID001", parameters);
                list = SQLHelper.ToList<MembershipDataTransfer>(dt);
            }
            return list;
        }
    }
}
