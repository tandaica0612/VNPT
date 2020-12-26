using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class MembershipPropertyDataTransfer : MembershipProperty
    {
        public string ProductName { get; set; }
        public string NhanVien { get; set; }
        public ModelTemplate NhanVienQuanLy { get; set; }
    }
}
