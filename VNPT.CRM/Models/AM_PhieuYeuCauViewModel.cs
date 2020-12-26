using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;

namespace VNPT.CRM.Models
{
    public class AM_PhieuYeuCauViewModel
    {
        public AM_PhieuYeuCauDataTransfer AM_PhieuYeuCauDataTransfer { get; set; }
        public AM_PhieuYeuCau AM_PhieuYeuCau { get; set; }
        public Membership Membership { get; set; }
        public Membership NguoiTao { get; set; }
    }
}
