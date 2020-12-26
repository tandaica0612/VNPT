using System;
using System.Collections.Generic;

namespace VNPT.Data.Models
{
    public partial class AM_PhieuYeuCau : BaseModel
    {
        public DateTime? NgayTao { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string KetQua { get; set; }
        public int? NguoiTaoID { get; set; }
        public int? NguoiNhanID { get; set; }
        public int? PhongBanID { get; set; }
        public int? ProductID { get; set; }
        public bool? DaGui { get; set; }
        public bool? DaNhan { get; set; }
        public bool? DangXuLy { get; set; }
        public bool? HoanThanh { get; set; }
        public string TaxCode { get; set; }
        public int? KhachHangID { get; set; }
        public string NguoiTao { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public int? HeThongID { get; set; }
        public int? MauHoaDonID { get; set; }
        public int? MauSoID { get; set; }
        public string KyHieu { get; set; }
        public string HeThong { get; set; }
        public string MauHoaDon { get; set; }
        public string MauSo { get; set; }
        public int? SoLuongHoaDon { get; set; }
        public int? NgonNguID { get; set; }
    }
}
