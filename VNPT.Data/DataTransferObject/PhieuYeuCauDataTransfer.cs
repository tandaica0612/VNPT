using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class PhieuYeuCauDataTransfer : PhieuYeuCau
    {
        public string ProductName { get; set; }        
        public string NguoiNhan { get; set; }
        public string KhachHang { get; set; }
    }
}
