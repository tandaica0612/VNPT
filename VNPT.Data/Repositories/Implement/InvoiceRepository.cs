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
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly VNPTContext _context;

        public InvoiceRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        public Invoice GetByContractIDAndYearAndMonth(int contractID, int year, int month)
        {
            Invoice item = _context.Set<Invoice>().FirstOrDefault(item => item.ContractID.Equals(contractID) && item.Year.Equals(year) && item.Month.Equals(month));
            return item;
        }
        public List<ReportPropertyDataTransfer> ReportSelect004ToList()
        {
            List<ReportPropertyDataTransfer> list = new List<ReportPropertyDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ReportSelect004");
            list = SQLHelper.ToList<ReportPropertyDataTransfer>(dt);
            return list;
        }
        public List<ReportPropertyDataTransfer> ReportSelect000ToList()
        {
            List<ReportPropertyDataTransfer> list = new List<ReportPropertyDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ReportSelect000");
            list = SQLHelper.ToList<ReportPropertyDataTransfer>(dt);
            return list;
        }
        public ReportPropertyDataTransfer ReportSelect001()
        {
            List<ReportPropertyDataTransfer> list = new List<ReportPropertyDataTransfer>();
            DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ReportSelect001");
            list = SQLHelper.ToList<ReportPropertyDataTransfer>(dt);
            ReportPropertyDataTransfer model = new ReportPropertyDataTransfer();
            if (list.Count > 0)
            {
                model = list[0];
            }
            return model;
        }
        public List<ReportPropertyDataTransfer> ReportSelect002ByYearToList(int year)
        {
            List<ReportPropertyDataTransfer> list = new List<ReportPropertyDataTransfer>();
            if (year > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@year",year)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ReportSelect002ByYear", parameters);
                list = SQLHelper.ToList<ReportPropertyDataTransfer>(dt);
            }
            return list;
        }
        public List<ReportPropertyDataTransfer> ReportSelect003ByYearToList(int year)
        {
            List<ReportPropertyDataTransfer> list = new List<ReportPropertyDataTransfer>();
            if (year > 0)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@year",year)
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.ConectionString, "sp_ReportSelect003ByYear", parameters);
                list = SQLHelper.ToList<ReportPropertyDataTransfer>(dt);
            }
            return list;
        }
    }
}
