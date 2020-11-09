using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using VNPT.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace VNPT.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
        }
        public IActionResult Index()
        {
            PhieuYeuCau model = new PhieuYeuCau();
            return View(model);
        }
        public IActionResult LoiCamOn()
        {            
            return View();
        }
    }
}
