using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IAM_PhieuYeuCauRepository : IRepository<AM_PhieuYeuCau>
    {
        public AM_PhieuYeuCauDataTransfer GetSQLByID(int ID);
    }
}
