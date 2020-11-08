using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;

namespace VNPT.CRM.Models
{
    public class PhieuYeuCauViewModel
    {
        public PhieuYeuCauDataTransfer PhieuYeuCauDataTransfer { get; set; }
        public PhieuYeuCau_ThuocTinhDataTransfer PhieuYeuCau_ThuocTinhDataTransfer { get; set; }
        public List<PhieuYeuCau_ThuocTinhDataTransfer> ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan { get; set; }
        public List<PhieuYeuCau_ThuocTinhDataTransfer> ListPhieuYeuCau_ThuocTinhDataTransferDinhKem { get; set; }
    }
}
