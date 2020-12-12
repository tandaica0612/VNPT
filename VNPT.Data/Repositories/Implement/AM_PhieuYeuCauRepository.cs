using VNPT.Data.DataTransferObject;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace VNPT.Data.Repositories
{
    public class AM_PhieuYeuCauRepository : Repository<AM_PhieuYeuCau>, IAM_PhieuYeuCauRepository
    {
        private readonly VNPTContext _context;

        public AM_PhieuYeuCauRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public AM_PhieuYeuCauDataTransfer GetSQLByID(int ID)
        {
            AM_PhieuYeuCauDataTransfer model = new AM_PhieuYeuCauDataTransfer();
            if (ID > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ID",ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_AM_PhieuYeuCauSelectByID", parameters);
                model = SQLHelper.ToList<AM_PhieuYeuCauDataTransfer>(dt).FirstOrDefault();
            }
            return model;
        }
    }
}
