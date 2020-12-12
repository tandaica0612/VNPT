using System;
using System.Collections.Generic;
using VNPT.Data.Helpers;

namespace VNPT.Data.Models
{
    public partial class AM_PhieuYeuCau_ThuocTinh : BaseModel
    {
        public DateTime? NgayTao { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int? NguoiTaoID { get; set; }
        public int? PhieuYeuCauID { get; set; }
    }
}
