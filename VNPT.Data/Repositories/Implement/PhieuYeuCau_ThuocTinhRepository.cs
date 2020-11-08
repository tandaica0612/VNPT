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
    public class PhieuYeuCau_ThuocTinhRepository : Repository<PhieuYeuCau_ThuocTinh>, IPhieuYeuCau_ThuocTinhRepository
    {
        private readonly VNPTContext _context;

        public PhieuYeuCau_ThuocTinhRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDToList(int phieuYeuCauID)
        {
            return _context.PhieuYeuCau_ThuocTinh.Where(item => item.PhieuYeuCauID == phieuYeuCauID).OrderBy(item => item.DateUpdated).ToList();
        }
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndParentIDToList(int phieuYeuCauID, int parentID)
        {
            return _context.PhieuYeuCau_ThuocTinh.Where(item => item.PhieuYeuCauID == phieuYeuCauID && item.ParentID == parentID).OrderBy(item => item.DateUpdated).ToList();
        }
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndParentIDAndCodeToList(int phieuYeuCauID, int parentID, string code)
        {
            return _context.PhieuYeuCau_ThuocTinh.Where(item => item.PhieuYeuCauID == phieuYeuCauID && item.ParentID == parentID && item.Code.Equals(code)).OrderBy(item => item.DateUpdated).ToList();
        }
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndCodeToList(int phieuYeuCauID, string code)
        {
            return _context.PhieuYeuCau_ThuocTinh.Where(item => item.PhieuYeuCauID == phieuYeuCauID && item.Code.Equals(code)).OrderBy(item => item.DateUpdated).ToList();
        }
        public List<PhieuYeuCau_ThuocTinhDataTransfer> GetPhieuYeuCau_ThuocTinhDataTransferByPhieuYeuCauIDAndCodeToList(int phieuYeuCauID, string code)
        {
            List<PhieuYeuCau_ThuocTinhDataTransfer> list = new List<PhieuYeuCau_ThuocTinhDataTransfer>();
            if ((phieuYeuCauID > 0) && (!string.IsNullOrEmpty(code)))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@PhieuYeuCauID",phieuYeuCauID),
                new SqlParameter("@Code",code),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_PhieuYeuCau_ThuocTinhSelectByPhieuYeuCauIDAndCode", parameters);
                list = SQLHelper.ToList<PhieuYeuCau_ThuocTinhDataTransfer>(dt);
            }
            return list;
        }
    }
}
