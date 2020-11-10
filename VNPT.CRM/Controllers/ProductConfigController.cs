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
    public class ProductConfigController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProductConfigRepository _productConfigRepository;
        public ProductConfigController(IWebHostEnvironment hostingEnvironment, IProductConfigRepository productConfigRepository) : base()
        {
            _hostingEnvironment = hostingEnvironment;
            _productConfigRepository = productConfigRepository;
        }
       
        public ActionResult GetByParentIDToList([DataSourceRequest] DataSourceRequest request, int parentID)
        {
            var data = _productConfigRepository.GetByParentIDToList(parentID);
            return Json(data.ToDataSourceResult(request));
        }
        public IActionResult Delete(int ID)
        {
            string note = AppGlobal.InitString;
            int result = _productConfigRepository.Delete(ID);
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.DeleteSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.DeleteFail;
            }
            return Json(note);
        }       
    }
}
