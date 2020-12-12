using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class AM_PhieuYeuCauDataTransfer : AM_PhieuYeuCau
    {
        public int? TongCong { get; set; }
        public int? DaGuiCount { get; set; }
        public int? DaNhanCount { get; set; }
        public int? DangXuLyCount { get; set; }
        public int? HoanThanhCount { get; set; }
        public string KhachHang { get; set; }
        public string NgonNgu { get; set; }
        public bool DaGui001
        {
            get; set;           
        }
        public bool DaNhan001
        {
            get; set;           
        }
        public bool DangXuLy001
        {
            get; set;           
        }
        public bool HoanThanh001
        {
            get; set;
        }
        public string NgayTaoString
        {
            get
            {
                string result = "";
                if(NgayTao!=null)
                {
                    result= NgayTao.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }    
                return result;
            }
        }
        public string KetQuaString
        {
            get
            {
                string result = KetQua;
                if (string.IsNullOrEmpty(result))
                {
                    result = "";
                }
                return result;
            }
        }
    }
}
