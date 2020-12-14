using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IAM_PhieuYeuCau_ThuocTinhRepository : IRepository<AM_PhieuYeuCau_ThuocTinh>
    {
        public List<AM_PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndParentIDAndCodeToList(int phieuYeuCauID, int parentID, string code);
    }
}
