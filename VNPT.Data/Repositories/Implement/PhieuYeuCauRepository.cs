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
    public class PhieuYeuCauRepository : Repository<PhieuYeuCau>, IPhieuYeuCauRepository
    {
        private readonly VNPTContext _context;

        public PhieuYeuCauRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public PhieuYeuCauDataTransfer GetPhieuYeuCauDataTransferByID(int ID)
        {
            PhieuYeuCauDataTransfer model = new PhieuYeuCauDataTransfer();
            if (ID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ID",ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_PhieuYeuCauSelectByID", parameters);
                model = SQLHelper.ToList<PhieuYeuCauDataTransfer>(dt).FirstOrDefault();
            }
            return model;
        }
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh)
        {
            List<PhieuYeuCauDataTransfer> list = new List<PhieuYeuCauDataTransfer>();
            if (year > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@DaGui",daGui),
                new SqlParameter("@DangXuLy",dangXuLy),
                new SqlParameter("@HoanThanh",hoanThanh),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_PhieuYeuCauSelectByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanh", parameters);
                list = SQLHelper.ToList<PhieuYeuCauDataTransfer>(dt);
            }
            return list;
        }
        public List<PhieuYeuCau> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhDoKhachHangGuiToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh)
        {
            List<PhieuYeuCau> list = new List<PhieuYeuCau>();
            list = _context.Set<PhieuYeuCau>().Where(item => item.NgayTao.Value.Year == year && item.NgayTao.Value.Month == month && item.NguoiTao == null && (item.DaGui.Value == daGui || item.DangXuLy.Value == dangXuLy || item.HoanThanh.Value == hoanThanh)).OrderBy(item => item.NgayTao).ToList();
            return list;
        }
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoID001ToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int nguoiTaoID)
        {
            List<PhieuYeuCauDataTransfer> list = new List<PhieuYeuCauDataTransfer>();
            if (nguoiTaoID == AppGlobal.NguyenVietDungID)
            {
                list = GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhToList(year, month, daGui, dangXuLy, hoanThanh);
            }
            else
            {
                list = GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoIDToList(year, month, daGui, dangXuLy, hoanThanh, nguoiTaoID);
            }
            return list;
        }
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoIDToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int nguoiTaoID)
        {
            List<PhieuYeuCauDataTransfer> list = new List<PhieuYeuCauDataTransfer>();
            if (year > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@DaGui",daGui),
                new SqlParameter("@DangXuLy",dangXuLy),
                new SqlParameter("@HoanThanh",hoanThanh),
                 new SqlParameter("@NguoiTaoID",nguoiTaoID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_PhieuYeuCauSelectByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoID", parameters);
                list = SQLHelper.ToList<PhieuYeuCauDataTransfer>(dt);
            }
            return list;
        }
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductIDToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int productID)
        {
            List<PhieuYeuCauDataTransfer> list = new List<PhieuYeuCauDataTransfer>();
            if (year > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@DaGui",daGui),
                new SqlParameter("@DangXuLy",dangXuLy),
                new SqlParameter("@HoanThanh",hoanThanh),
                new SqlParameter("@ProductID",productID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_PhieuYeuCauSelectByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductID", parameters);
                list = SQLHelper.ToList<PhieuYeuCauDataTransfer>(dt);
            }
            return list;
        }
        public List<PhieuYeuCauDataTransfer> GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductIDAndActionToList(int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int productID, int action)
        {
            List<PhieuYeuCauDataTransfer> list = new List<PhieuYeuCauDataTransfer>();
            switch (action)
            {
                case 0:
                    list = GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhToList(year, month, daGui, dangXuLy, hoanThanh);
                    break;
                case 1:
                    list = GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductIDToList(year, month, daGui, dangXuLy, hoanThanh, productID);
                    break;
            }
            return list;
        }
    }
}
