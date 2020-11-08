using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IPhieuYeuCau_ThuocTinhRepository : IRepository<PhieuYeuCau_ThuocTinh>
    {
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDToList(int phieuYeuCauID);
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndParentIDToList(int phieuYeuCauID, int parentID);
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndParentIDAndCodeToList(int phieuYeuCauID, int parentID, string code);
        public List<PhieuYeuCau_ThuocTinh> GetByPhieuYeuCauIDAndCodeToList(int phieuYeuCauID, string code);
        public List<PhieuYeuCau_ThuocTinhDataTransfer> GetPhieuYeuCau_ThuocTinhDataTransferByPhieuYeuCauIDAndCodeToList(int phieuYeuCauID, string code);
    }
}
