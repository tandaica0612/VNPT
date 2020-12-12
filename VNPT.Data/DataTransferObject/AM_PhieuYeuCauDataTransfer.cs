using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class AM_PhieuYeuCauDataTransfer : AM_PhieuYeuCau
    {        
        public string KhachHang { get; set; }
        public string NgonNgu { get; set; }
    }
}
