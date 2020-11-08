using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VNPT.Data.Repositories;
using VNPT.Data.Models;
using VNPT.Data.Helpers;
using VNPT.Data.Enum;
using VNPT.Data.DataTransferObject;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using VNPT.CRM.Models;

namespace VNPT.CRM.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public ReportController(IInvoiceRepository invoiceRepository) : base()
        {
            _invoiceRepository = invoiceRepository;
        }
        public IActionResult Index()
        {
            ReportViewModel model = new ReportViewModel();
            model.YearFinance = DateTime.Now.Year;
            model.MonthFinance = DateTime.Now.Month - 1;
            ReportPropertyDataTransfer reportPropertyDataTransfer = _invoiceRepository.ReportSelect001();
            if (reportPropertyDataTransfer != null)
            {
                model.MembershipIDCount = reportPropertyDataTransfer.MembershipIDCount;
                model.MembershipIDPropertyCount = reportPropertyDataTransfer.MembershipIDPropertyCount;
                model.RevenueByYear = reportPropertyDataTransfer.RevenueByYear;
                model.RevenueByYearAndMonth = reportPropertyDataTransfer.RevenueByYearAndMonth;
            }
            return View(model);
        }
        public IActionResult CustomerNotRevenueByYearAndMonth()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public IActionResult CustomerNotRevenueByYearAndMonthAndProductID()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public IActionResult CustomerNotRevenueByYearAndMonthAndProductIDAndCityID()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public ActionResult ReportSelect004ToList()
        {
            List<ReportPropertyDataTransfer> list = _invoiceRepository.ReportSelect004ToList();
            return Json(list);
        }
        public ActionResult ReportSelect000ToList()
        {
            List<ReportPropertyDataTransfer> list = _invoiceRepository.ReportSelect000ToList();
            return Json(list);
        }
        public ActionResult ReportSelect002ByYearNowToList()
        {
            List<ReportPropertyDataTransfer> list = _invoiceRepository.ReportSelect002ByYearToList(DateTime.Now.Year);
            return Json(list);
        }
        public ActionResult ReportSelect003ByYearNowToList()
        {
            List<ReportPropertyDataTransfer> list = _invoiceRepository.ReportSelect003ByYearToList(DateTime.Now.Year);
            return Json(list);
        }
    }
}
