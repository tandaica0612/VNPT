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
using Microsoft.AspNetCore.Http;

namespace VNPT.CRM.Controllers
{
    public class MembershipController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipPropertyRepository _membershipPropertyRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoicePropertyRepository _invoicePropertyRepository;
        private readonly IConfigRepository _configResposistory;

        public MembershipController(IWebHostEnvironment hostingEnvironment, IMembershipRepository membershipRepository, IMembershipPropertyRepository membershipPropertyRepository, IInvoiceRepository invoiceRepository, IInvoicePropertyRepository invoicePropertyRepository, IConfigRepository configResposistory) : base()
        {
            _hostingEnvironment = hostingEnvironment;
            _membershipRepository = membershipRepository;
            _membershipPropertyRepository = membershipPropertyRepository;
            _invoiceRepository = invoiceRepository;
            _invoicePropertyRepository = invoicePropertyRepository;
            _configResposistory = configResposistory;
        }
        private void Initialization(Membership model, int action)
        {
            if (!string.IsNullOrEmpty(model.FullName))
            {
                model.FullName = model.FullName.Trim();
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                model.Email = model.Email.Trim();
            }
            if (!string.IsNullOrEmpty(model.Phone))
            {
                model.Phone = model.Phone.Trim();
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                model.Password = "0";
            }
            switch (action)
            {
                case 0:
                    model.InitDefaultValue();
                    model.EncryptPassword();
                    break;
                case 1:
                    Membership model001 = _membershipRepository.GetByID(model.ID);
                    if (model001 != null)
                    {
                        if (model.Password != model001.Password)
                        {
                            model.EncryptPassword();
                        }
                    }
                    break;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult CustomerList()
        {
            return View();
        }
        public IActionResult Employee()
        {
            return View();
        }
        public IActionResult EmployeeDetail(int ID)
        {
            Membership model = new Membership();
            if (ID > 0)
            {
                model = _membershipRepository.GetByID(ID);
            }
            return View(model);
        }
        public IActionResult EmployeeInfo()
        {
            Membership model = new Membership();
            if (this.RequestUserID > 0)
            {
                model = _membershipRepository.GetByID(this.RequestUserID);
            }
            return View(model);
        }
        public IActionResult CustomerByProduct()
        {
            return View();
        }
        public IActionResult CustomerNotByProduct()
        {
            return View();
        }
        public IActionResult Login(Membership model)
        {
            string controller = "Home";
            string action = "Index";
            Membership membership = _membershipRepository.GetByPhoneAndPassword(model.Phone, model.Password);
            if (membership != null)
            {
                var CookieExpires = new CookieOptions();
                CookieExpires.Expires = DateTime.Now.AddMonths(2);
                Response.Cookies.Append("UserID", membership.ID.ToString(), CookieExpires);
                controller = "PhieuYeuCau";
                action = "DanhSachByNhanVienID";
                if (membership.ID == AppGlobal.NguyenVietDungID)
                {
                    controller = "PhieuYeuCau";
                    action = "DanhSach";
                }
            }
            return RedirectToAction(action, controller);
        }
        public IActionResult CustomerDetail(int ID)
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            viewModel.Membership = new Membership();
            if (ID > 0)
            {
                viewModel.Membership = _membershipRepository.GetByID(ID);
            }
            if (viewModel.Membership == null)
            {
                viewModel.Membership = new Membership();
            }
            viewModel.Membership.ParentID = AppGlobal.DoanhNghiepID;
            return View(viewModel);
        }
        public IActionResult CustomerDetail001(int ID)
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            viewModel.Membership = new Membership();
            if (ID > 0)
            {
                viewModel.Membership = _membershipRepository.GetByID(ID);
            }
            if (viewModel.Membership == null)
            {
                viewModel.Membership = new Membership();
            }
            viewModel.Membership.ParentID = AppGlobal.DoanhNghiepID;
            return View(viewModel);
        }
        public IActionResult CustomerDetailWithWindow(int ID)
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            viewModel.Membership = new Membership();
            if (ID > 0)
            {
                viewModel.Membership = _membershipRepository.GetByID(ID);
            }
            if (viewModel.Membership == null)
            {
                viewModel.Membership = new Membership();
            }
            viewModel.Membership.ParentID = AppGlobal.DoanhNghiepID;
            return View(viewModel);
        }
        public IActionResult Upload()
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel.YearFinance = DateTime.Now.Year;
            viewModel.MonthFinance = DateTime.Now.Month;
            return View(viewModel);
        }
        public Membership GetByID(int ID)
        {
            Membership model = new Membership();
            if (ID > 0)
            {
                model = _membershipRepository.GetByID(ID);
            }
            return model;
        }
        public ActionResult GetMembershipDataTransferKhachHangToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _membershipRepository.GetMembershipDataTransferByParentIDToList(AppGlobal.DoanhNghiepID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetDoanhNghiepAndSeachStringToList([DataSourceRequest] DataSourceRequest request, string searchString)
        {
            var data = _membershipRepository.GetParentIDAndSeachStringToList(AppGlobal.DoanhNghiepID, searchString);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetSQLDoanhNghiepToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _membershipRepository.GetSQLByParentIDToList(AppGlobal.DoanhNghiepID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetSQLDoanhNghiep001ToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _membershipRepository.GetSQLMembershipDataTransferByParentID001ToList(AppGlobal.DoanhNghiepID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetDoanhNghiepToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _membershipRepository.GetByParentIDToList(AppGlobal.DoanhNghiepID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetNhanVienToList([DataSourceRequest] DataSourceRequest request)
        {
            var data = _membershipRepository.GetByParentIDToList(AppGlobal.NhanVienID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByCityIDToList([DataSourceRequest] DataSourceRequest request, int cityID)
        {
            var data = _membershipRepository.GetByCityIDToList(cityID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetNotRevenueByYearAndMonthToList([DataSourceRequest] DataSourceRequest request, int year, int month)
        {
            var data = _membershipRepository.GetNotRevenueByYearAndMonthToList(year, month);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetNotRevenueByYearAndMonthAndProductIDToList([DataSourceRequest] DataSourceRequest request, int year, int month, int productID)
        {
            var data = _membershipRepository.GetNotRevenueByYearAndMonthAndProductIDToList(year, month, productID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetNotRevenueByYearAndMonthAndProductIDAndCityIDToList([DataSourceRequest] DataSourceRequest request, int year, int month, int productID, int cityID)
        {
            var data = _membershipRepository.GetNotRevenueByYearAndMonthAndProductIDAndCityIDToList(year, month, productID, cityID);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByProductIDAndCityIDAndActionToList([DataSourceRequest] DataSourceRequest request, int productID, int cityID, int action)
        {
            var data = _membershipRepository.GetByProductIDAndCityIDAndActionToList(productID, cityID, action);
            return Json(data.ToDataSourceResult(request));
        }
        public ActionResult GetByProductIDNotAndCityIDAndActionToList([DataSourceRequest] DataSourceRequest request, int productID, int cityID, int action)
        {
            var data = _membershipRepository.GetByProductIDNotAndCityIDAndActionToList(productID, cityID, action);
            return Json(data.ToDataSourceResult(request));
        }
        [AcceptVerbs("Post")]
        public IActionResult SaveCustomer(BaseViewModel model)
        {
            Membership membership = model.Membership;
            if (membership.ID > 0)
            {
                Initialization(membership, 1);
                membership.Initialization(InitType.Update, RequestUserID);
                _membershipRepository.Update(membership.ID, membership);
            }
            else
            {
                Initialization(membership, 0);
                membership.Initialization(InitType.Insert, RequestUserID);
                _membershipRepository.Create(membership);
            }
            return RedirectToAction("CustomerDetail", new { ID = model.ID });
        }
        [AcceptVerbs("Post")]
        public IActionResult SaveEmployee(Membership model)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = AppGlobal.SetName(fileName);
                    fileName = model.Phone + fileExtension;
                    var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, "images/Membership", fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        model.Image = fileName;
                    }
                }
            }

            if (model.ID > 0)
            {
                Initialization(model, 1);
                model.Initialization(InitType.Update, RequestUserID);
                _membershipRepository.Update(model.ID, model);
            }
            else
            {
                Initialization(model, 0);
                model.Initialization(InitType.Insert, RequestUserID);
                _membershipRepository.Create(model);
            }
            return RedirectToAction("EmployeeDetail", new { ID = model.ID });
        }
        [AcceptVerbs("Post")]
        public IActionResult SaveCustomerWithWindow(BaseViewModel model)
        {
            Membership membership = model.Membership;
            if (membership.ID > 0)
            {
                Initialization(membership, 1);
                membership.Initialization(InitType.Update, RequestUserID);
                _membershipRepository.Update(membership.ID, membership);
            }
            else
            {
                Initialization(membership, 0);
                membership.Initialization(InitType.Insert, RequestUserID);
                _membershipRepository.Create(membership);
            }
            return RedirectToAction("CustomerDetailWithWindow", new { ID = model.ID });
        }
        public IActionResult CreateNhanVien(Membership model)
        {
            string note = AppGlobal.InitString;
            int result = 0;
            Initialization(model, 0);
            model.ParentID = AppGlobal.NhanVienID;
            model.Initialization(InitType.Insert, RequestUserID);
            result = _membershipRepository.Create(model);
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
        public IActionResult Update(Membership model)
        {
            string note = AppGlobal.InitString;
            int result = 0;
            Initialization(model, 1);
            model.Initialization(InitType.Update, RequestUserID);
            result = _membershipRepository.Update(model.ID, model);
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
            int result = _membershipRepository.Delete(ID);
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
        public ActionResult UploadInvoice(BaseViewModel viewModel)
        {
            int result = 0;
            string action = "Upload";
            string controller = "Membership";
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        fileName = "Invoice";
                        fileName = fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                        var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.FTPUploadExcel, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    Membership model = new Membership();
                                                    if (workSheet.Cells[i, 7].Value != null)
                                                    {
                                                        model.TaxCode = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                        model.TaxCode = model.TaxCode.Replace(@" ", @"");
                                                        model = _membershipRepository.GetByTaxCode(model.TaxCode);
                                                        if (model != null)
                                                        {
                                                            MembershipProperty membershipProperty = new MembershipProperty();
                                                            membershipProperty.MembershipID = model.ID;
                                                            if (workSheet.Cells[i, 1].Value != null)
                                                            {
                                                                membershipProperty.PaymentCode = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                            }
                                                            if (workSheet.Cells[i, 2].Value != null)
                                                            {
                                                                membershipProperty.ProductCode = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                            }
                                                            decimal valueContract = 0;
                                                            if (workSheet.Cells[i, 3].Value != null)
                                                            {
                                                                try
                                                                {
                                                                    valueContract = decimal.Parse(workSheet.Cells[i, 3].Value.ToString().Trim());
                                                                }
                                                                catch
                                                                {
                                                                }
                                                            }
                                                            membershipProperty = _membershipPropertyRepository.GetByMembershipIDAndPaymentCodeAndProductCode(membershipProperty.MembershipID.Value, membershipProperty.PaymentCode, membershipProperty.ProductCode);
                                                            if (membershipProperty == null)
                                                            {
                                                                membershipProperty = new MembershipProperty();
                                                                membershipProperty.MembershipID = model.ID;
                                                                if (workSheet.Cells[i, 1].Value != null)
                                                                {
                                                                    membershipProperty.PaymentCode = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                                }
                                                                if (workSheet.Cells[i, 2].Value != null)
                                                                {
                                                                    membershipProperty.ProductCode = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                                }
                                                                Config product = new Config();
                                                                if (workSheet.Cells[i, 4].Value != null)
                                                                {
                                                                    product.Title = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                                    product = _configResposistory.GetByGroupNameAndCodeAndTitle(AppGlobal.CRM, AppGlobal.Product, product.Title);
                                                                    if (product == null)
                                                                    {
                                                                        product = new Config();
                                                                        product.Initialization(InitType.Insert, RequestUserID);
                                                                        product.GroupName = AppGlobal.CRM;
                                                                        product.Code = AppGlobal.Product;
                                                                        product.Title = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                                        _configResposistory.Create(product);
                                                                    }
                                                                    membershipProperty.ProductID = product.ID;
                                                                }

                                                                if (membershipProperty.MembershipID > 0)
                                                                {
                                                                    membershipProperty.ValueContract = valueContract;
                                                                    membershipProperty.DateBegin = DateTime.Now;
                                                                    membershipProperty.DateEnd = DateTime.Now;
                                                                    membershipProperty.DateContract = DateTime.Now;
                                                                    membershipProperty.Address = model.Address;
                                                                    membershipProperty.Initialization(InitType.Insert, RequestUserID);
                                                                    _membershipPropertyRepository.Create(membershipProperty);
                                                                }
                                                            }
                                                            if (membershipProperty != null)
                                                            {
                                                                Invoice invoice = new Invoice();
                                                                invoice.ContractID = membershipProperty.ID;
                                                                invoice.Year = viewModel.YearFinance;
                                                                invoice.Month = viewModel.MonthFinance;
                                                                invoice = _invoiceRepository.GetByContractIDAndYearAndMonth(invoice.ContractID.Value, invoice.Year.Value, invoice.Month.Value);
                                                                if (invoice == null)
                                                                {
                                                                    invoice = new Invoice();
                                                                    invoice.ContractID = membershipProperty.ID;
                                                                    invoice.Year = viewModel.YearFinance;
                                                                    invoice.Month = viewModel.MonthFinance;
                                                                    invoice.Initialization(InitType.Insert, RequestUserID);
                                                                    invoice.ContractID = membershipProperty.ID;
                                                                    invoice.Year = viewModel.YearFinance;
                                                                    invoice.Month = viewModel.MonthFinance;
                                                                    invoice.DateInvoice = new DateTime(invoice.Year.Value, invoice.Month.Value, 28);
                                                                    invoice.Total = valueContract;
                                                                    _invoiceRepository.Create(invoice);
                                                                }
                                                                if (invoice != null)
                                                                {
                                                                    InvoiceProperty invoiceProperty = _invoicePropertyRepository.GetByInvoiceIDAndProductID(invoice.ID, membershipProperty.ProductID.Value);
                                                                    if (invoiceProperty == null)
                                                                    {
                                                                        invoiceProperty = new InvoiceProperty();
                                                                        invoiceProperty.Initialization(InitType.Insert, RequestUserID);
                                                                        invoiceProperty.InvoiceID = invoice.ID;
                                                                        invoiceProperty.ProductID = membershipProperty.ProductID;
                                                                        invoiceProperty.UnitID = AppGlobal.UnitID;
                                                                        invoiceProperty.Quantity = 1;
                                                                        invoiceProperty.UnitPrice = valueContract;
                                                                        invoiceProperty.Total = invoiceProperty.Quantity * invoiceProperty.UnitPrice;
                                                                        _invoicePropertyRepository.Create(invoiceProperty);
                                                                    }

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                result = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            if (result > 0)
            {
                action = "Customer";
                controller = "Membership";
            }
            return RedirectToAction(action, controller, new { ID = result });
        }
        public ActionResult UploadInvoiceBySQL(BaseViewModel viewModel)
        {
            int result = 0;
            string action = "Upload";
            string controller = "Membership";
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        fileName = "Invoice";
                        fileName = fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                        var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.FTPUploadExcel, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    string taxCode = "";
                                                    string paymentCode = "";
                                                    string productCode = "";
                                                    string productName = "";
                                                    decimal valueContract = 0;
                                                    if (workSheet.Cells[i, 1].Value != null)
                                                    {
                                                        paymentCode = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 2].Value != null)
                                                    {
                                                        productCode = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 3].Value != null)
                                                    {
                                                        try
                                                        {
                                                            valueContract = decimal.Parse(workSheet.Cells[i, 3].Value.ToString().Trim());
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                    if (workSheet.Cells[i, 4].Value != null)
                                                    {
                                                        productName = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 7].Value != null)
                                                    {
                                                        taxCode = workSheet.Cells[i, 7].Value.ToString().Trim();
                                                        taxCode = taxCode.Replace(@" ", @"");
                                                    }
                                                    _membershipRepository.UploadInvoiceByYearAndMonth(RequestUserID, viewModel.YearFinance, viewModel.MonthFinance, taxCode, paymentCode, productCode, productName, AppGlobal.CRM, AppGlobal.Product, valueContract);
                                                }
                                                result = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            if (result > 0)
            {
                action = "Customer";
                controller = "Membership";
            }
            return RedirectToAction(action, controller, new { ID = result });
        }
        public ActionResult UploadCustomer()
        {
            int result = 0;
            string action = "Upload";
            string controller = "Membership";
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    if (file == null || file.Length == 0)
                    {
                    }
                    if (file != null)
                    {
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        fileName = "Customer";
                        fileName = fileName + "-" + AppGlobal.DateTimeCode + fileExtension;
                        var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, AppGlobal.FTPUploadExcel, fileName);
                        using (var stream = new FileStream(physicalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            FileInfo fileLocation = new FileInfo(physicalPath);
                            if (fileLocation.Length > 0)
                            {
                                if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                                {
                                    using (ExcelPackage package = new ExcelPackage(stream))
                                    {
                                        if (package.Workbook.Worksheets.Count > 0)
                                        {
                                            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                            if (workSheet != null)
                                            {
                                                int totalRows = workSheet.Dimension.Rows;
                                                for (int i = 2; i <= totalRows; i++)
                                                {
                                                    Membership model = new Membership();
                                                    if (workSheet.Cells[i, 1].Value != null)
                                                    {
                                                        model.FullName = workSheet.Cells[i, 1].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 2].Value != null)
                                                    {
                                                        model.ShortName = workSheet.Cells[i, 2].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 3].Value != null)
                                                    {
                                                        model.FirstName = workSheet.Cells[i, 3].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 4].Value != null)
                                                    {
                                                        model.TaxCode = workSheet.Cells[i, 4].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 6].Value != null)
                                                    {
                                                        model.Address = workSheet.Cells[i, 6].Value.ToString().Trim();
                                                    }
                                                    Config province = new Config();
                                                    Config city = new Config();
                                                    Config ward = new Config();
                                                    if (workSheet.Cells[i, 8].Value != null)
                                                    {
                                                        province.Title = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                        province = _configResposistory.GetByGroupNameAndCodeAndTitle(AppGlobal.CRM, AppGlobal.Province, province.Title);
                                                        if (province == null)
                                                        {
                                                            province = new Config();
                                                            province.Initialization(InitType.Insert, RequestUserID);
                                                            province.GroupName = AppGlobal.CRM;
                                                            province.Code = AppGlobal.Province;
                                                            province.Title = workSheet.Cells[i, 8].Value.ToString().Trim();
                                                            _configResposistory.Create(province);
                                                        }
                                                        model.ProvinceID = province.ID;
                                                    }

                                                    if (workSheet.Cells[i, 9].Value != null)
                                                    {
                                                        city.Title = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                        city = _configResposistory.GetByGroupNameAndCodeAndTitle(AppGlobal.CRM, AppGlobal.City, city.Title);
                                                        if (city == null)
                                                        {
                                                            city = new Config();
                                                            city.ParentID = province.ID;
                                                            city.Initialization(InitType.Insert, RequestUserID);
                                                            city.GroupName = AppGlobal.CRM;
                                                            city.Code = AppGlobal.City;
                                                            city.Title = workSheet.Cells[i, 9].Value.ToString().Trim();
                                                            _configResposistory.Create(city);
                                                        }
                                                        model.CityID = city.ID;
                                                    }
                                                    if (workSheet.Cells[i, 10].Value != null)
                                                    {
                                                        ward.Title = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                        ward = _configResposistory.GetByGroupNameAndCodeAndTitle(AppGlobal.CRM, AppGlobal.Ward, ward.Title);
                                                        if (ward == null)
                                                        {
                                                            ward = new Config();
                                                            ward.ParentID = city.ID;
                                                            ward.Initialization(InitType.Insert, RequestUserID);
                                                            ward.GroupName = AppGlobal.CRM;
                                                            ward.Code = AppGlobal.Ward;
                                                            ward.Title = workSheet.Cells[i, 10].Value.ToString().Trim();
                                                            _configResposistory.Create(ward);
                                                        }
                                                        model.WardID = ward.ID;
                                                    }
                                                    if (workSheet.Cells[i, 12].Value != null)
                                                    {
                                                        model.ContactFullName = workSheet.Cells[i, 12].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 13].Value != null)
                                                    {
                                                        model.Phone = workSheet.Cells[i, 13].Value.ToString().Trim();
                                                    }
                                                    if (workSheet.Cells[i, 14].Value != null)
                                                    {
                                                        model.ContactPhone = workSheet.Cells[i, 14].Value.ToString().Trim();
                                                    }
                                                    Config customerType = new Config();
                                                    if (workSheet.Cells[i, 25].Value != null)
                                                    {
                                                        customerType.Title = workSheet.Cells[i, 25].Value.ToString().Trim();
                                                        customerType = _configResposistory.GetByGroupNameAndCodeAndTitle(AppGlobal.CRM, AppGlobal.CustomerType, customerType.Title);
                                                        if (customerType == null)
                                                        {
                                                            customerType = new Config();
                                                            customerType.Initialization(InitType.Insert, RequestUserID);
                                                            customerType.GroupName = AppGlobal.CRM;
                                                            customerType.Code = AppGlobal.CustomerType;
                                                            customerType.Title = workSheet.Cells[i, 25].Value.ToString().Trim();
                                                            _configResposistory.Create(customerType);
                                                        }
                                                        model.CategoryID = customerType.ID;
                                                    }
                                                    if (workSheet.Cells[i, 37].Value != null)
                                                    {
                                                        model.MembershipCode = workSheet.Cells[i, 37].Value.ToString().Trim();
                                                    }
                                                    model.Initialization(InitType.Insert, RequestUserID);
                                                    model.ParentID = AppGlobal.DoanhNghiepID;
                                                    Membership membership = _membershipRepository.GetByTaxCode(model.TaxCode);
                                                    if (membership == null)
                                                    {
                                                        _membershipRepository.Create(model);
                                                    }

                                                }
                                                result = 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            if (result > 0)
            {
                action = "Customer";
                controller = "Membership";
            }
            return RedirectToAction(action, controller, new { ID = result });
        }
    }
}
