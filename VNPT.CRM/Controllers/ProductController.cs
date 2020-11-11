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
    public class ProductController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IProductRepository _productRepository;
        private readonly IProductConfigRepository _productConfigRepository;
        public ProductController(IWebHostEnvironment hostingEnvironment, IProductRepository productRepository, IProductConfigRepository productConfigRepository) : base()
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = productRepository;
            _productConfigRepository = productConfigRepository;
        }
        public IActionResult DanhSach()
        {
            return View();
        }
        public IActionResult Detail(int ID)
        {
            Product model = new Product();
            if (ID > 0)
            {
                model = _productRepository.GetByID(ID);
            }
            return View(model);
        }
        public IActionResult DetailFiles(int ID)
        {
            Product model = new Product();
            if (ID > 0)
            {
                model = _productRepository.GetByID(ID);
            }
            return View(model);
        }
        public ActionResult GetByParentIDToList([DataSourceRequest] DataSourceRequest request, int parentID)
        {
            var data = _productRepository.GetByParentIDToList(parentID);
            return Json(data.ToDataSourceResult(request));
        }
        public IActionResult Delete(int ID)
        {
            string note = AppGlobal.InitString;
            int result = _productRepository.Delete(ID);
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
        [AcceptVerbs("Post")]
        public IActionResult SaveChange(Product model)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = AppGlobal.SetName(model.Title);
                    fileName = fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                    var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.URLProduct, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        model.ImageThumbnail = fileName;
                        model.Image = AppGlobal.Domain + AppGlobal.URLProduct + "/" + model.ImageThumbnail;
                    }
                }
            }
            if (string.IsNullOrEmpty(model.MetaTitle))
            {
                model.MetaTitle = AppGlobal.SetName(model.Title);
            }
            if (model.ID > 0)
            {
                model.Initialization(InitType.Update, RequestUserID);
                _productRepository.Update(model.ID, model);
            }
            else
            {
                model.Initialization(InitType.Insert, RequestUserID);
                _productRepository.Create(model);
            }
            if (model.ID > 0)
            {

            }
            string controller = "Product";
            string action = "Detail";
            return RedirectToAction(action, controller, new { ID = model.ID });
        }
        [AcceptVerbs("Post")]
        public IActionResult SaveFiles(Product model)
        {
            if (Request.Form.Files.Count > 0)
            {
                List<ProductConfig> list = new List<ProductConfig>();
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);

                        fileName = AppGlobal.SetName(fileName);
                        fileName = model.ID + "-" + fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                        var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.URLProduct, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            ProductConfig productConfig = new ProductConfig();
                            productConfig.Initialization(InitType.Insert, RequestUserID);
                            productConfig.ParentID = model.ID;
                            productConfig.Title = model.Title;
                            productConfig.FileName = fileName;
                            productConfig.URL = AppGlobal.Domain + AppGlobal.URLProduct + "/" + fileName;
                            productConfig.Note = fileExtension;
                            try
                            {
                                _productConfigRepository.Create(productConfig);
                            }
                            catch (Exception e)
                            {
                                string mes = e.Message;
                            }
                        }
                    }
                }
            }
            return RedirectToAction("DetailFiles", "Product", new { ID = model.ID });
        }
    }
}
