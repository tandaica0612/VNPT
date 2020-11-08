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
    public class MembershipPropertyController : BaseController
    {

        private readonly IMembershipPropertyRepository _membershipPropertyRepository;

        public MembershipPropertyController(IMembershipPropertyRepository membershipPropertyRepository) : base()
        {
            _membershipPropertyRepository = membershipPropertyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataTransferProductByMembershipIDToList([DataSourceRequest] DataSourceRequest request, int membershipID)
        {
            var data = _membershipPropertyRepository.GetDataTransferProductByMembershipIDToList(membershipID);
            return Json(data.ToDataSourceResult(request));
        }

    }
}
