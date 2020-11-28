using System;
using System.Text;
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
    public class PhieuYeuCauController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IPhieuYeuCauRepository _phieuYeuCauRepository;
        private readonly IPhieuYeuCau_ThuocTinhRepository _phieuYeuCau_ThuocTinhRepository;
        public PhieuYeuCauController(IWebHostEnvironment hostingEnvironment, IMembershipRepository membershipRepository, IPhieuYeuCauRepository phieuYeuCauRepository, IPhieuYeuCau_ThuocTinhRepository phieuYeuCau_ThuocTinhRepository) : base()
        {
            _hostingEnvironment = hostingEnvironment;
            _membershipRepository = membershipRepository;
            _phieuYeuCauRepository = phieuYeuCauRepository;
            _phieuYeuCau_ThuocTinhRepository = phieuYeuCau_ThuocTinhRepository;
        }

        public IActionResult DanhSachByNhanVienID()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public IActionResult DetailByNhanVienID(int ID)
        {
            PhieuYeuCau model = new PhieuYeuCau();
            model.NgayTao = DateTime.Now;
            model.DaGui = true;
            if (ID > 0)
            {
                model = _phieuYeuCauRepository.GetByID(ID);
            }
            return View(model);
        }
        public IActionResult InfoByNhanVienID(int ID)
        {
            PhieuYeuCauViewModel model = new PhieuYeuCauViewModel();
            if (ID > 0)
            {
                model.ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan = new List<PhieuYeuCau_ThuocTinhDataTransfer>();
                model.PhieuYeuCauDataTransfer = _phieuYeuCauRepository.GetPhieuYeuCauDataTransferByID(ID);
                PhieuYeuCau_ThuocTinhDataTransfer phieuYeuCau_ThuocTinhDataTransfer = new PhieuYeuCau_ThuocTinhDataTransfer();
                phieuYeuCau_ThuocTinhDataTransfer.Title = model.PhieuYeuCauDataTransfer.NoiDung;
                phieuYeuCau_ThuocTinhDataTransfer.ID = model.PhieuYeuCauDataTransfer.ID;
                phieuYeuCau_ThuocTinhDataTransfer.ParentID = model.PhieuYeuCauDataTransfer.ID;
                phieuYeuCau_ThuocTinhDataTransfer.PhieuYeuCauID = model.PhieuYeuCauDataTransfer.ID;
                model.ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan.Add(phieuYeuCau_ThuocTinhDataTransfer);
                model.ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan.AddRange(_phieuYeuCau_ThuocTinhRepository.GetPhieuYeuCau_ThuocTinhDataTransferByPhieuYeuCauIDAndCodeToList(ID, AppGlobal.PhieuYeuCauPhanHoi));
                model.ListPhieuYeuCau_ThuocTinhDataTransferDinhKem = _phieuYeuCau_ThuocTinhRepository.GetPhieuYeuCau_ThuocTinhDataTransferByPhieuYeuCauIDAndCodeToList(ID, AppGlobal.PhieuYeuCauDinhKem);
            }
            return View(model);
        }
        public IActionResult DanhSach()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public IActionResult DanhSachDoKhachHangGui()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public IActionResult Detail(int ID)
        {
            PhieuYeuCau model = new PhieuYeuCau();
            model.NgayTao = DateTime.Now;
            model.DaGui = true;
            if (ID > 0)
            {
                model = _phieuYeuCauRepository.GetByID(ID);
            }
            return View(model);
        }
        public IActionResult Info(int ID)
        {
            PhieuYeuCauViewModel model = new PhieuYeuCauViewModel();
            if (ID > 0)
            {
                model.ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan = new List<PhieuYeuCau_ThuocTinhDataTransfer>();
                model.PhieuYeuCauDataTransfer = _phieuYeuCauRepository.GetPhieuYeuCauDataTransferByID(ID);
                PhieuYeuCau_ThuocTinhDataTransfer phieuYeuCau_ThuocTinhDataTransfer = new PhieuYeuCau_ThuocTinhDataTransfer();
                phieuYeuCau_ThuocTinhDataTransfer.Title = model.PhieuYeuCauDataTransfer.NoiDung;
                phieuYeuCau_ThuocTinhDataTransfer.ID = model.PhieuYeuCauDataTransfer.ID;
                phieuYeuCau_ThuocTinhDataTransfer.ParentID = model.PhieuYeuCauDataTransfer.ID;
                phieuYeuCau_ThuocTinhDataTransfer.PhieuYeuCauID = model.PhieuYeuCauDataTransfer.ID;
                model.ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan.Add(phieuYeuCau_ThuocTinhDataTransfer);
                model.ListPhieuYeuCau_ThuocTinhDataTransferBinhLuan.AddRange(_phieuYeuCau_ThuocTinhRepository.GetPhieuYeuCau_ThuocTinhDataTransferByPhieuYeuCauIDAndCodeToList(ID, AppGlobal.PhieuYeuCauPhanHoi));
                model.ListPhieuYeuCau_ThuocTinhDataTransferDinhKem = _phieuYeuCau_ThuocTinhRepository.GetPhieuYeuCau_ThuocTinhDataTransferByPhieuYeuCauIDAndCodeToList(ID, AppGlobal.PhieuYeuCauDinhKem);
            }
            return View(model);
        }
        public ActionResult GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhDoKhachHangGuiToList([DataSourceRequest] DataSourceRequest request, int year, int month, bool daGui, bool dangXuLy, bool hoanThanh)
        {
            var data = _phieuYeuCauRepository.GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhDoKhachHangGuiToList(year, month, daGui, dangXuLy, hoanThanh);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByYearAndMonthDoKhachHangGuiToList([DataSourceRequest] DataSourceRequest request, int year, int month)
        {
            var data = _phieuYeuCauRepository.GetByYearAndMonthDoKhachHangGuiToList(year, month);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByYearAndMonthAndNguoiTaoIDToList([DataSourceRequest] DataSourceRequest request, int year, int month)
        {
            var data = _phieuYeuCauRepository.GetByYearAndMonthAndNguoiTaoIDToList(year, month, RequestUserID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoID001ToList([DataSourceRequest] DataSourceRequest request, int year, int month, bool daGui, bool dangXuLy, bool hoanThanh)
        {
            var data = _phieuYeuCauRepository.GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndNguoiTaoID001ToList(year, month, daGui, dangXuLy, hoanThanh, RequestUserID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductIDAndActionToList([DataSourceRequest] DataSourceRequest request, int year, int month, bool daGui, bool dangXuLy, bool hoanThanh, int productID, int action)
        {
            var data = _phieuYeuCauRepository.GetByYearAndMonthAndDaGuiAndDangXuLyAndHoanThanhAndProductIDAndActionToList(year, month, daGui, dangXuLy, hoanThanh, productID, action);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetDinhKemByPhieuYeuCauIDToListJSON(int ID)
        {
            return Json(_phieuYeuCau_ThuocTinhRepository.GetByPhieuYeuCauIDAndParentIDAndCodeToList(ID, ID, AppGlobal.PhieuYeuCauDinhKem));
        }
        public IActionResult Delete(int ID)
        {
            string note = AppGlobal.InitString;
            int result = _phieuYeuCauRepository.Delete(ID);
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
        public IActionResult SavePhieuYeuCau(PhieuYeuCau model)
        {
            model.NgayTao = new DateTime(model.NgayTao.Value.Year, model.NgayTao.Value.Month, model.NgayTao.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            if (model.ID > 0)
            {
                model.Initialization(InitType.Update, RequestUserID);
                _phieuYeuCauRepository.Update(model.ID, model);
            }
            else
            {
                model.Initialization(InitType.Insert, RequestUserID);
                _phieuYeuCauRepository.Create(model);
            }
            if (model.ID > 0)
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
                            fileName = AppGlobal.SetName(model.TieuDe);
                            fileName = model.ID + "-" + fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                            var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.URLPhieuYeuCau, fileName);
                            using (var stream = new FileStream(physicalPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                PhieuYeuCau_ThuocTinh phieuYeuCau_ThuocTinh = new PhieuYeuCau_ThuocTinh();
                                phieuYeuCau_ThuocTinh.Initialization(InitType.Insert, RequestUserID);
                                phieuYeuCau_ThuocTinh.Code = AppGlobal.PhieuYeuCauDinhKem;
                                phieuYeuCau_ThuocTinh.NguoiTaoID = RequestUserID;
                                phieuYeuCau_ThuocTinh.NgayTao = DateTime.Now;
                                phieuYeuCau_ThuocTinh.PhieuYeuCauID = model.ID;
                                phieuYeuCau_ThuocTinh.ParentID = model.ID;
                                phieuYeuCau_ThuocTinh.Title = fileName;
                                phieuYeuCau_ThuocTinh.URL = AppGlobal.DomainSub + "/" + AppGlobal.URLPhieuYeuCau + "/" + phieuYeuCau_ThuocTinh.Title;
                                _phieuYeuCau_ThuocTinhRepository.Create(phieuYeuCau_ThuocTinh);
                                if ((fileExtension.Contains(@".png") == true) || (fileExtension.Contains(@".jpg") == true) || (fileExtension.Contains(@".gif") == true) || (fileExtension.Contains(@".ipeg") == true) || (fileExtension.Contains(@".webp") == true))
                                {
                                    txt.AppendLine("<br/>");
                                    txt.AppendLine("<img src='" + phieuYeuCau_ThuocTinh.URL + "' class='img-thumbnail' alt='" + model.TieuDe + "' title='" + model.TieuDe + "' />");
                                }
                            }
                        }
                    }
                    model.NoiDung = model.NoiDung + txt.ToString();
                    _phieuYeuCauRepository.Update(model.ID, model);
                }
            }
            string controller = "PhieuYeuCau";
            string action = "DetailByNhanVienID";
            if (RequestUserID == AppGlobal.NguyenVietDungID)
            {
                action = "Detail";
            }
            return RedirectToAction(action, controller, new { ID = model.ID });
        }
        [AcceptVerbs("Post")]
        public IActionResult SavePhieuYeuCau_ThuocTinh(PhieuYeuCauViewModel model)
        {
            if ((model.PhieuYeuCauDataTransfer.ID > 0) && (model.PhieuYeuCau_ThuocTinhDataTransfer != null))
            {
                PhieuYeuCau phieuYeuCau = _phieuYeuCauRepository.GetByID(model.PhieuYeuCauDataTransfer.ID);
                if (phieuYeuCau != null)
                {
                    phieuYeuCau.DangXuLy = model.PhieuYeuCau_ThuocTinhDataTransfer.DangXuLy001;
                    phieuYeuCau.HoanThanh = model.PhieuYeuCau_ThuocTinhDataTransfer.HoanThanh001;
                    _phieuYeuCauRepository.Update(phieuYeuCau.ID, phieuYeuCau);
                    PhieuYeuCau_ThuocTinh phieuYeuCau_ThuocTinhBinhLuan = model.PhieuYeuCau_ThuocTinhDataTransfer;
                    phieuYeuCau_ThuocTinhBinhLuan.NguoiTaoID = RequestUserID;
                    phieuYeuCau_ThuocTinhBinhLuan.NgayTao = DateTime.Now;
                    phieuYeuCau_ThuocTinhBinhLuan.PhieuYeuCauID = model.PhieuYeuCauDataTransfer.ID;
                    phieuYeuCau_ThuocTinhBinhLuan.ParentID = model.PhieuYeuCauDataTransfer.ID;
                    phieuYeuCau_ThuocTinhBinhLuan.Code = AppGlobal.PhieuYeuCauPhanHoi;
                    if (phieuYeuCau_ThuocTinhBinhLuan.ID > 0)
                    {

                        phieuYeuCau_ThuocTinhBinhLuan.Initialization(InitType.Update, RequestUserID);
                        _phieuYeuCau_ThuocTinhRepository.Update(phieuYeuCau_ThuocTinhBinhLuan.ID, phieuYeuCau_ThuocTinhBinhLuan);
                    }
                    else
                    {
                        phieuYeuCau_ThuocTinhBinhLuan.Initialization(InitType.Insert, RequestUserID);
                        _phieuYeuCau_ThuocTinhRepository.Create(phieuYeuCau_ThuocTinhBinhLuan);
                    }
                    if (phieuYeuCau_ThuocTinhBinhLuan.ID > 0)
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
                                    fileName = AppGlobal.SetName(model.PhieuYeuCauDataTransfer.TieuDe);
                                    fileName = phieuYeuCau_ThuocTinhBinhLuan.PhieuYeuCauID + "-" + phieuYeuCau_ThuocTinhBinhLuan.ID + "-" + fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                                    var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.URLPhieuYeuCau, fileName);
                                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                                    {
                                        file.CopyTo(stream);
                                        PhieuYeuCau_ThuocTinh phieuYeuCau_ThuocTinh = new PhieuYeuCau_ThuocTinh();
                                        phieuYeuCau_ThuocTinh.Initialization(InitType.Insert, RequestUserID);
                                        phieuYeuCau_ThuocTinh.Code = AppGlobal.PhieuYeuCauDinhKem;
                                        phieuYeuCau_ThuocTinh.NguoiTaoID = RequestUserID;
                                        phieuYeuCau_ThuocTinh.NgayTao = DateTime.Now;
                                        phieuYeuCau_ThuocTinh.PhieuYeuCauID = phieuYeuCau_ThuocTinhBinhLuan.PhieuYeuCauID;
                                        phieuYeuCau_ThuocTinh.ParentID = phieuYeuCau_ThuocTinhBinhLuan.ID;
                                        phieuYeuCau_ThuocTinh.Title = fileName;
                                        _phieuYeuCau_ThuocTinhRepository.Create(phieuYeuCau_ThuocTinh);

                                        if ((fileExtension.Contains(@".png") == true) || (fileExtension.Contains(@".jpg") == true) || (fileExtension.Contains(@".gif") == true) || (fileExtension.Contains(@".ipeg") == true) || (fileExtension.Contains(@".webp") == true))
                                        {
                                            string url = "/" + AppGlobal.URLPhieuYeuCau + "/" + fileName;
                                            txt.AppendLine("<br/>");
                                            txt.AppendLine("<img src='" + url + "' class='img-thumbnail' alt='" + model.PhieuYeuCauDataTransfer.TieuDe + "' title='" + model.PhieuYeuCauDataTransfer.TieuDe + "' />");
                                        }
                                    }
                                }
                            }
                            phieuYeuCau_ThuocTinhBinhLuan.Title = phieuYeuCau_ThuocTinhBinhLuan.Title + txt.ToString();
                            _phieuYeuCau_ThuocTinhRepository.Update(phieuYeuCau_ThuocTinhBinhLuan.ID, phieuYeuCau_ThuocTinhBinhLuan);
                        }
                    }
                }
            }
            string controller = "PhieuYeuCau";
            string action = "InfoByNhanVienID";
            if (RequestUserID == AppGlobal.NguyenVietDungID)
            {
                action = "Info";
            }
            return RedirectToAction(action, controller, new { ID = model.PhieuYeuCauDataTransfer.ID });
        }
    }
}
