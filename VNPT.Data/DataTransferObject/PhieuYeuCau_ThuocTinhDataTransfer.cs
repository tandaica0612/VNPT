using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class PhieuYeuCau_ThuocTinhDataTransfer : PhieuYeuCau_ThuocTinh
    {
        public string NguoiTao { get; set; }
        public bool DangXuLy001 { get; set; }
        public bool HoanThanh001 { get; set; }       
    }
}
