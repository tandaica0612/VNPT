using System;
using System.Collections.Generic;

namespace VNPT.Data.Models
{
    public partial class PhieuYeuCau : BaseModel
    {
        public DateTime? NgayTao { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }      
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
    }
}
