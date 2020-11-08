using VNPT.Data.DataTransferObject;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNPT.Data.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public Invoice GetByContractIDAndYearAndMonth(int contractID, int year, int month);
        public List<ReportPropertyDataTransfer> ReportSelect004ToList();
        public List<ReportPropertyDataTransfer> ReportSelect000ToList();
        public ReportPropertyDataTransfer ReportSelect001();
        public List<ReportPropertyDataTransfer> ReportSelect002ByYearToList(int year);
        public List<ReportPropertyDataTransfer> ReportSelect003ByYearToList(int year);
    }
}
