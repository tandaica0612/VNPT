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
    public class AM_PhieuYeuCau_ThuocTinhRepository : Repository<AM_PhieuYeuCau_ThuocTinh>, IAM_PhieuYeuCau_ThuocTinhRepository
    {
        private readonly VNPTContext _context;

        public AM_PhieuYeuCau_ThuocTinhRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public List<AM_PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndParentIDAndCodeToList(int phieuYeuCauID, int parentID, string code)
        {
            return _context.AM_PhieuYeuCau_ThuocTinh.Where(item => item.PhieuYeuCauID == phieuYeuCauID && item.ParentID == parentID && item.Code.Equals(code)).OrderBy(item => item.DateUpdated).ToList();
        }
    }
}
