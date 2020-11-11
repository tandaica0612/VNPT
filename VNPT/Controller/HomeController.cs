using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using VNPT.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using VNPT.Models;

namespace VNPT.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IConfigRepository _configRepository;
        private readonly IProductRepository _productRepository;
        public HomeController(IConfigRepository configRepository, IProductRepository productRepository) : base()
        {
            _configRepository = configRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.ListLoaiBaiViet = _configRepository.GetByGroupNameAndCodeToList(AppGlobal.CRM, AppGlobal.LoaiBaiViet);
            model.ListProduct = _productRepository.GetByParentIDToList(832).OrderByDescending(item => item.DateUpdated).ToList();
            return View(model);
        }
        public IActionResult LoiCamOn()
        {
            return View();
        }
    }
}
