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
using VNPT.Models;

namespace VNPT.Controllers
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

        [AcceptVerbs("Post")]
        public IActionResult SavePhieuYeuCau(BaseViewModel baseViewModel)
        {
            PhieuYeuCau model = baseViewModel.PhieuYeuCau;
            model.DaGui = true;
            model.DangXuLy = false;
            model.HoanThanh = false;
            model.NgayTao = DateTime.Now;
            if (!string.IsNullOrEmpty(model.TaxCode))
            {
                Membership membership = _membershipRepository.GetByTaxCode(model.TaxCode);
                if (membership != null)
                {
                    model.KhachHangID = membership.ID;
                }
            }
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
            string controller = "Home";
            string action = "LoiCamOn";
            return RedirectToAction(action, controller);
        }

    }
}
