using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IPhieuYeuCauRepository : IRepository<PhieuYeuCau>
    {
        public List<PhieuYeuCau> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhDoKhachHangGuiToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh);
        public PhieuYeuCauDataTransfer GetPhieuYeuCauDataTransferByID(int ID);
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoID001ToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int nguoiTaoID);
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductIDAndActionToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int productID, int action);
    }
}
