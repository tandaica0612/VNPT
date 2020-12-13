using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IAM_PhieuYeuCauRepository : IRepository<AM_PhieuYeuCau>
    {
        public AM_PhieuYeuCauDataTransfer GetSQLByID(int ID);
        public AM_PhieuYeuCauDataTransfer GetCount();
        public List<AM_PhieuYeuCauDataTransfer> GetDaGuiToList();
        public List<AM_PhieuYeuCauDataTransfer> GetDaNhanToList();
        public List<AM_PhieuYeuCauDataTransfer> GetDangXuLyToList();
        public List<AM_PhieuYeuCauDataTransfer> GetHoanThanhToList();
        public List<AM_PhieuYeuCauDataTransfer> GetByNguoiTaoIDToList(int nguoiTaoID);
        public List<AM_PhieuYeuCauDataTransfer> GetHoanThanhByNguoiTaoIDToList(int nguoiTaoID);
    }
}
