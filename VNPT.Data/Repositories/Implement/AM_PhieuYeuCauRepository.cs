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
    public class AM_PhieuYeuCauRepository : Repository<AM_PhieuYeuCau>, IAM_PhieuYeuCauRepository
    {
        private readonly VNPTContext _context;

        public AM_PhieuYeuCauRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public AM_PhieuYeuCauDataTransfer GetSQLByID(int ID)
        {
            AM_PhieuYeuCauDataTransfer model = new AM_PhieuYeuCauDataTransfer();
            if (ID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ID",ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectByID", parameters);
                model = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).FirstOrDefault();
                if (model.DaGui != null)
                {
                    model.DaGui001 = model.DaGui.Value;
                }
                if (model.DaNhan != null)
                {
                    model.DaNhan001 = model.DaNhan.Value;
                }
                if (model.DangXuLy != null)
                {
                    model.DangXuLy001 = model.DangXuLy.Value;
                }
                if (model.HoanThanh != null)
                {
                    model.HoanThanh001 = model.HoanThanh.Value;
                }
            }
            return model;
        }
        public AM_PhieuYeuCauDataTransfer GetCount()
        {
            AM_PhieuYeuCauDataTransfer model = new AM_PhieuYeuCauDataTransfer();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectCount");
            model = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).FirstOrDefault();
            return model;
        }
        public List<AM_PhieuYeuCauDataTransfer> GetDaGuiToList()
        {
            List<AM_PhieuYeuCauDataTransfer> list = new List<AM_PhieuYeuCauDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectDaGui");
            list = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).ToList();
            return list;
        }

        public List<AM_PhieuYeuCauDataTransfer> GetDaNhanToList()
        {
            List<AM_PhieuYeuCauDataTransfer> list = new List<AM_PhieuYeuCauDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectDaNhan");
            list = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).ToList();
            return list;
        }
        public List<AM_PhieuYeuCauDataTransfer> GetDangXuLyToList()
        {
            List<AM_PhieuYeuCauDataTransfer> list = new List<AM_PhieuYeuCauDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectDangXuLy");
            list = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).ToList();
            return list;
        }
        public List<AM_PhieuYeuCauDataTransfer> GetHoanThanhToList()
        {
            List<AM_PhieuYeuCauDataTransfer> list = new List<AM_PhieuYeuCauDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectHoanThanh");
            list = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).ToList();
            return list;
        }
        public List<AM_PhieuYeuCauDataTransfer> GetAllItemsToList()
        {
            List<AM_PhieuYeuCauDataTransfer> list = new List<AM_PhieuYeuCauDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectAllItems");
            list = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).ToList();
            return list;
        }
        public List<AM_PhieuYeuCauDataTransfer> GetByNguoiTaoIDToList(int nguoiTaoID)
        {
            List<AM_PhieuYeuCauDataTransfer> list = new List<AM_PhieuYeuCauDataTransfer>();
            if (nguoiTaoID > 0)
            {
                if (nguoiTaoID == AppGlobal.NguyenVietDungID)
                {
                    list = GetAllItemsToList();
                }
                else
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@NguoiTaoID",nguoiTaoID),
                    };
                    DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectByNguoiTaoID", parameters);
                    list = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).ToList();
                }
            }
            return list;
        }

    }
}
