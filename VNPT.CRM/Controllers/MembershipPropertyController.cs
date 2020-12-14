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
using VNPT.Data.DataTransferObject;

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
        public ActionResult GetDataTransferProductByMembershipIDAndCodeToList([DataSourceRequest] DataSourceRequest request, int membershipID)
        {
            var data = _membershipPropertyRepository.GetDataTransferProductByMembershipIDAndCodeToList(membershipID, AppGlobal.Product);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetDataTransferNhanVienByMembershipIDAndCodeToList([DataSourceRequest] DataSourceRequest request, int membershipID)
        {
            var data = _membershipPropertyRepository.GetDataTransferNhanVienByMembershipIDAndCodeToList(membershipID, AppGlobal.NhanVien);
            return Json(data.ToDataSourceResult(request));
        }
        public IActionResult CreateNhanVien(MembershipPropertyDataTransfer model, int membershipID)
        {
            string note = AppGlobal.InitString;
            int result = 0;
            if (model.NhanVienQuanLy.ID > 0)
            {
                model.ProductID = model.NhanVienQuanLy.ID;
                model.Code = AppGlobal.NhanVien;
                model.MembershipID = membershipID;               
                model.Initialization(InitType.Insert, RequestUserID);
                result = _membershipPropertyRepository.Create(model);
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
        public IActionResult UpdateProduct(MembershipProperty model)
        {
            model.Code = AppGlobal.Product;
            string note = AppGlobal.InitString;
            int result = 0;
            model.Initialization(InitType.Update, RequestUserID);
            result = _membershipPropertyRepository.Update(model.ID, model);
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
        public IActionResult UpdateNhanVien(MembershipPropertyDataTransfer model)
        {
            
            string note = AppGlobal.InitString;
            int result = 0;
            if (model.NhanVienQuanLy.ID > 0)
            {
                model.ProductID = model.NhanVienQuanLy.ID;
                model.Code = AppGlobal.NhanVien;
                model.Initialization(InitType.Update, RequestUserID);
                result = _membershipPropertyRepository.Update(model.ID, model);
            }
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
            int result = _membershipPropertyRepository.Delete(ID);
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
