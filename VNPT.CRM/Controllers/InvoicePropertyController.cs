using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Enum;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using VNPT.Data.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting.Internal;
using OfficeOpenXml;
using VNPT.CRM.Models;

namespace VNPT.CRM.Controllers
{
    public class InvoicePropertyController : BaseController
    {

        private readonly IInvoicePropertyRepository _invoicePropertyRepository;

        public InvoicePropertyController(IInvoicePropertyRepository invoicePropertyRepository) : base()
        {
            _invoicePropertyRepository = invoicePropertyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataTransferProductByMembershipIDAndYearAndMonthToList([DataSourceRequest] DataSourceRequest request, int membershipID, int year, int month)
        {
            var data = _invoicePropertyRepository.GetDataTransferProductByMembershipIDAndYearAndMonthToList(membershipID, year, month);
            return Json(data.ToDataSourceResult(request));
        }

    }
}
