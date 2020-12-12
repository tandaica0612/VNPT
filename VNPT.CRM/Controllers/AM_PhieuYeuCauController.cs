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
using System.Text;

namespace VNPT.CRM.Controllers
{
    public class AM_PhieuYeuCauController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAM_PhieuYeuCauRepository _aM_PhieuYeuCauResposistory;
        private readonly IMembershipRepository _membershipResposistory;
        private readonly IAM_PhieuYeuCau_ThuocTinhRepository _aM_PhieuYeuCau_ThuocTinhRepository;
        public AM_PhieuYeuCauController(IWebHostEnvironment hostingEnvironment, IAM_PhieuYeuCauRepository aM_PhieuYeuCauRepository, IAM_PhieuYeuCau_ThuocTinhRepository aM_PhieuYeuCau_ThuocTinhRepository, IMembershipRepository membershipResposistory) : base()
        {
            _hostingEnvironment = hostingEnvironment;
            _aM_PhieuYeuCauResposistory = aM_PhieuYeuCauRepository;
            _aM_PhieuYeuCau_ThuocTinhRepository = aM_PhieuYeuCau_ThuocTinhRepository;
            _membershipResposistory = membershipResposistory;
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Detail(int ID)
        {
            AM_PhieuYeuCauViewModel model = new AM_PhieuYeuCauViewModel();
            if (ID > 0)
            {
                model.AM_PhieuYeuCau = _aM_PhieuYeuCauResposistory.GetByID(ID);
                if (model.AM_PhieuYeuCau.KhachHangID > 0)
                {
                    model.Membership = _membershipResposistory.GetByID(model.AM_PhieuYeuCau.KhachHangID.Value);
                }
            }
            if (model.AM_PhieuYeuCau == null)
            {
                model.AM_PhieuYeuCau = new AM_PhieuYeuCau();
                model.AM_PhieuYeuCau.TieuDe = "";
            }
            if (model.Membership == null)
            {
                model.Membership = new Membership();
            }
            return View(model);
        }
        public IActionResult Info(int ID)
        {
            AM_PhieuYeuCauViewModel model = new AM_PhieuYeuCauViewModel();
            if (ID > 0)
            {
                model.AM_PhieuYeuCauDataTransfer = _aM_PhieuYeuCauResposistory.GetSQLByID(ID);
                if (model.AM_PhieuYeuCauDataTransfer.KhachHangID > 0)
                {
                    model.Membership = _membershipResposistory.GetByID(model.AM_PhieuYeuCauDataTransfer.KhachHangID.Value);
                }
                if (model.AM_PhieuYeuCauDataTransfer.NguoiTaoID > 0)
                {
                    model.NguoiTao = _membershipResposistory.GetByID(model.AM_PhieuYeuCauDataTransfer.NguoiTaoID.Value);
                }
            }
            return View(model);
        }
        public ActionResult GetDinhKemByPhieuYeuCauIDToListJSON(int ID)
        {
            return Json(_aM_PhieuYeuCau_ThuocTinhRepository.GetByPhieuYeuCauIDAndParentIDAndCodeToList(ID, ID, AppGlobal.PhieuYeuCauDinhKem));
        }
        [AcceptVerbs("Post")]
        public IActionResult Save(AM_PhieuYeuCauViewModel model)
        {
            if (model.AM_PhieuYeuCau.KhachHangID > 0)
            {
                model.AM_PhieuYeuCau.DaGui = true;
                model.AM_PhieuYeuCau.NgayTao = DateTime.Now;
                model.AM_PhieuYeuCau.NguoiTaoID = RequestUserID;
                if (model.AM_PhieuYeuCau.ID > 0)
                {
                    model.AM_PhieuYeuCau.Initialization(InitType.Update, RequestUserID);
                    _aM_PhieuYeuCauResposistory.Update(model.AM_PhieuYeuCau.ID, model.AM_PhieuYeuCau);
                }
                else
                {
                    model.AM_PhieuYeuCau.Initialization(InitType.Insert, RequestUserID);
                    _aM_PhieuYeuCauResposistory.Create(model.AM_PhieuYeuCau);
                }
                if (model.AM_PhieuYeuCau.KhachHangID > 0)
                {
                    model.Membership.Initialization(InitType.Update, RequestUserID);
                    _membershipResposistory.Update(model.AM_PhieuYeuCau.KhachHangID.Value, model.Membership);
                }
                if (model.AM_PhieuYeuCau.ID > 0)
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        StringBuilder txt = new StringBuilder();
                        for (int i = 0; i < Request.Form.Files.Count; i++)
                        {
                            var file = Request.Form.Files[i];
                            if (file != null)
                            {
                                string fileExtension = Path.GetExtension(file.FileName);
                                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                                fileName = AppGlobal.SetName(model.AM_PhieuYeuCau.TieuDe);
                                fileName = model.AM_PhieuYeuCau.ID + "-" + fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                                var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.URLPhieuYeuCau, fileName);
                                using (var stream = new FileStream(physicalPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                    AM_PhieuYeuCau_ThuocTinh phieuYeuCau_ThuocTinh = new AM_PhieuYeuCau_ThuocTinh();
                                    phieuYeuCau_ThuocTinh.Initialization(InitType.Insert, RequestUserID);
                                    phieuYeuCau_ThuocTinh.Code = AppGlobal.PhieuYeuCauDinhKem;
                                    phieuYeuCau_ThuocTinh.NguoiTaoID = RequestUserID;
                                    phieuYeuCau_ThuocTinh.NgayTao = DateTime.Now;
                                    phieuYeuCau_ThuocTinh.PhieuYeuCauID = model.AM_PhieuYeuCau.ID;
                                    phieuYeuCau_ThuocTinh.ParentID = model.AM_PhieuYeuCau.ID;
                                    phieuYeuCau_ThuocTinh.Title = fileName;
                                    phieuYeuCau_ThuocTinh.URL = AppGlobal.DomainSub + "/" + AppGlobal.URLPhieuYeuCau + "/" + phieuYeuCau_ThuocTinh.Title;
                                    _aM_PhieuYeuCau_ThuocTinhRepository.Create(phieuYeuCau_ThuocTinh);
                                    if ((fileExtension.Contains(@".png") == true) || (fileExtension.Contains(@".jpg") == true) || (fileExtension.Contains(@".gif") == true) || (fileExtension.Contains(@".jpeg") == true) || (fileExtension.Contains(@".webp") == true))
                                    {
                                        txt.AppendLine("<br/>");
                                        txt.AppendLine("<img src='" + phieuYeuCau_ThuocTinh.URL + "' class='img-thumbnail' alt='" + model.AM_PhieuYeuCau.TieuDe + "' title='" + model.AM_PhieuYeuCau.TieuDe + "' />");
                                    }
                                }
                            }
                        }
                        model.AM_PhieuYeuCau.NoiDung = model.AM_PhieuYeuCau.NoiDung + txt.ToString();
                        _aM_PhieuYeuCauResposistory.Update(model.AM_PhieuYeuCau.ID, model.AM_PhieuYeuCau);
                    }
                }
            }
            string controller = "AM_PhieuYeuCau";
            string action = "Detail";
            return RedirectToAction(action, controller, new { ID = model.AM_PhieuYeuCau.ID });
        }
    }
}
