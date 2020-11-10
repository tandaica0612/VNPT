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


namespace VNPT.CRM.Controllers
{
    public class ConfigController : BaseController
    {

        private readonly IConfigRepository _configResposistory;

        public ConfigController(IConfigRepository configResposistory) : base()
        {
            _configResposistory = configResposistory;
        }
        private void Initialization(Config model)
        {
            if (!string.IsNullOrEmpty(model.Title))
            {
                model.Title = model.Title.Trim();
            }
            if (!string.IsNullOrEmpty(model.Note))
            {
                model.Note = model.Note.Trim();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MembershipType()
        {
            return View();
        }
        public IActionResult City()
        {
            return View();
        }
        public IActionResult CustomerType()
        {
            return View();
        }
        public IActionResult Province()
        {
            return View();
        }
        public IActionResult Ward()
        {
            return View();
        }
        public IActionResult Unit()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult LoaiBaiViet()
        {
            return View();
        }
        public ActionResult GetLoaiBaiVietToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.LoaiBaiViet);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetProductToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.Product);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetUnitToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.Unit);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetMembershipTypeToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.MembershipType);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetWardToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.Ward);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetProvinceToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.Province);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetCustomerTypeToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.CustomerType);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetCityToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _configResposistory.GetByGroupNameAndCodeToList(VNPT.Data.Helpers.AppGlobal.CRM, VNPT.Data.Helpers.AppGlobal.City);
            return Json(data.ToDataSourceResult(request));
        }
        public IActionResult CreateLoaiBaiViet(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.LoaiBaiViet;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateProduct(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.Product;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateUnit(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.Unit;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateMembershipType(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.MembershipType;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateWard(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.Ward;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateProvince(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.Province;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateCustomerType(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.CustomerType;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult CreateCity(Config model)
        {
            Initialization(model);
            model.GroupName = AppGlobal.CRM;
            model.Code = AppGlobal.City;
            model.ParentID = 0;
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Insert, RequestUserID);
            int result = 0;
            Config config = _configResposistory.GetByGroupNameAndCodeAndTitle(model.GroupName, model.Code, model.Title);
            if (config == null)
            {
                result = _configResposistory.Create(model);
            }
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.CreateSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.CreateFail;
            }
            return Json(note);
        }
        public IActionResult Update(Config model)
        {
            Initialization(model);
            string note = AppGlobal.InitString;
            model.Initialization(InitType.Update, RequestUserID);
            int result = _configResposistory.Update(model.ID, model);
            if (result > 0)
            {
                note = AppGlobal.Success + " - " + AppGlobal.EditSuccess;
            }
            else
            {
                note = AppGlobal.Error + " - " + AppGlobal.EditFail;
            }
            return Json(note);
        }
        public IActionResult Delete(int ID)
        {
            string note = AppGlobal.InitString;
            int result = _configResposistory.Delete(ID);
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
