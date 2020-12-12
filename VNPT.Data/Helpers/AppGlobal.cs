using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace VNPT.Data.Helpers
{
    public class AppGlobal
    {
        #region Init
        public static DateTime InitDateTime => DateTime.Now;

        public static string InitString => string.Empty;

        public static string DateTimeCode => DateTime.Now.ToString("yyyyMMddHHmmss");

        public static string InitGuiCode => Guid.NewGuid().ToString();
        #endregion

        #region AppSettings 
        public static string NganHang
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("NganHang").Value;
            }
        }
        public static string AMNgonNgu
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AMNgonNgu").Value;
            }
        }
        public static string AMMauHoaDon
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AMMauHoaDon").Value;
            }
        }
        public static string AMMauSo
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AMMauSo").Value;
            }
        }
        public static string AMHeThong
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("AMHeThong").Value;
            }
        }
        public static string LoaiPhieuYeuCau
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LoaiPhieuYeuCau").Value;
            }
        }
        public static string LoaiBaiViet
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("LoaiBaiViet").Value;
            }
        }
        public static string DomainSub
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DomainSub").Value;
            }
        }
        public static string PhieuYeuCauDinhKem
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PhieuYeuCauDinhKem").Value;
            }
        }
        public static string PhieuYeuCauPhanHoi
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("PhieuYeuCauPhanHoi").Value;
            }
        }
        public static string URLProduct
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLProduct").Value;
            }
        }
        public static string URLPhieuYeuCau
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLPhieuYeuCau").Value;
            }
        }
        public static string FTPUploadExcel
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("FTPUploadExcel").Value;
            }
        }
        public static string URLDownloadExcel
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("URLDownloadExcel").Value;
            }
        }
        public static int NguyenVietDungID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("NguyenVietDungID").Value);
            }
        }
        public static int DateBegin
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("DateBegin").Value);
            }
        }
        public static int DateEnd
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("DateEnd").Value);
            }
        }
        public static int UnitID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("UnitID").Value);
            }
        }
        public static int DoanhNghiepID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("DoanhNghiepID").Value);
            }
        }
        public static int NhanVienID
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return int.Parse(builder.Build().GetSection("AppSettings").GetSection("NhanVienID").Value);
            }
        }
        public static string CRM
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CRM").Value;
            }
        }
        public static string MembershipType
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MembershipType").Value;
            }
        }
        public static string CustomerType
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CustomerType").Value;
            }
        }
        public static string Province
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Province").Value;
            }
        }
        public static string City
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("City").Value;
            }
        }
        public static string Ward
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Ward").Value;
            }
        }
        public static string Product
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Product").Value;
            }
        }
        public static string Unit
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Unit").Value;
            }
        }
        public static string LoadingURLFull
        {
            get
            {
                string result = AppGlobal.Domain + AppGlobal.Images + "/" + AppGlobal.Loading;
                return result;
            }
        }
        public static string LogoURLFull
        {
            get
            {
                string result = AppGlobal.Domain + AppGlobal.Images + "/" + AppGlobal.Logo;
                return result;
            }
        }
        public static string Images
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Images").Value;
            }
        }
        public static string Loading
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Loading").Value;
            }
        }
        public static string Logo
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Logo").Value;
            }
        }
        public static string ConectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("ConectionString").Value;
            }
        }

        public static string Domain
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Domain").Value;
            }
        }


        public static string MD5Key
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("MD5Key").Value;
            }
        }


        public static string Title
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Title").Value;
            }
        }
        public static string EditSuccess
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("EditSuccess").Value;
            }
        }

        public static string EditFail
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("EditFail").Value;
            }
        }

        public static string CreateSuccess
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CreateSuccess").Value;
            }
        }

        public static string CreateFail
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("CreateFail").Value;
            }
        }

        public static string DeleteSuccess
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DeleteSuccess").Value;
            }
        }

        public static string DeleteFail
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("DeleteFail").Value;
            }
        }

        public static string Success
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Success").Value;
            }
        }

        public static string Error
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("Error").Value;
            }
        }

        #endregion
        #region Functions
        public static string SetName(string fileName)
        {
            string fileNameReturn = fileName;
            if (!string.IsNullOrEmpty(fileNameReturn))
            {
                fileNameReturn = fileNameReturn.ToLower();
                fileNameReturn = fileNameReturn.Replace("’", "-");
                fileNameReturn = fileNameReturn.Replace("“", "-");
                fileNameReturn = fileNameReturn.Replace("--", "-");
                fileNameReturn = fileNameReturn.Replace("+", "-");
                fileNameReturn = fileNameReturn.Replace("/", "-");
                fileNameReturn = fileNameReturn.Replace(@"\", "-");
                fileNameReturn = fileNameReturn.Replace(":", "-");
                fileNameReturn = fileNameReturn.Replace(";", "-");
                fileNameReturn = fileNameReturn.Replace("%", "-");
                fileNameReturn = fileNameReturn.Replace("`", "-");
                fileNameReturn = fileNameReturn.Replace("~", "-");
                fileNameReturn = fileNameReturn.Replace("#", "-");
                fileNameReturn = fileNameReturn.Replace("$", "-");
                fileNameReturn = fileNameReturn.Replace("^", "-");
                fileNameReturn = fileNameReturn.Replace("&", "-");
                fileNameReturn = fileNameReturn.Replace("*", "-");
                fileNameReturn = fileNameReturn.Replace("(", "-");
                fileNameReturn = fileNameReturn.Replace(")", "-");
                fileNameReturn = fileNameReturn.Replace("|", "-");
                fileNameReturn = fileNameReturn.Replace("'", "-");
                fileNameReturn = fileNameReturn.Replace(",", "-");
                fileNameReturn = fileNameReturn.Replace(".", "-");
                fileNameReturn = fileNameReturn.Replace("?", "-");
                fileNameReturn = fileNameReturn.Replace("<", "-");
                fileNameReturn = fileNameReturn.Replace(">", "-");
                fileNameReturn = fileNameReturn.Replace("]", "-");
                fileNameReturn = fileNameReturn.Replace("[", "-");
                fileNameReturn = fileNameReturn.Replace(@"""", "-");
                fileNameReturn = fileNameReturn.Replace(@" ", "-");
                fileNameReturn = fileNameReturn.Replace("á", "a");
                fileNameReturn = fileNameReturn.Replace("à", "a");
                fileNameReturn = fileNameReturn.Replace("ả", "a");
                fileNameReturn = fileNameReturn.Replace("ã", "a");
                fileNameReturn = fileNameReturn.Replace("ạ", "a");
                fileNameReturn = fileNameReturn.Replace("ă", "a");
                fileNameReturn = fileNameReturn.Replace("ắ", "a");
                fileNameReturn = fileNameReturn.Replace("ằ", "a");
                fileNameReturn = fileNameReturn.Replace("ẳ", "a");
                fileNameReturn = fileNameReturn.Replace("ẵ", "a");
                fileNameReturn = fileNameReturn.Replace("ặ", "a");
                fileNameReturn = fileNameReturn.Replace("â", "a");
                fileNameReturn = fileNameReturn.Replace("ấ", "a");
                fileNameReturn = fileNameReturn.Replace("ầ", "a");
                fileNameReturn = fileNameReturn.Replace("ẩ", "a");
                fileNameReturn = fileNameReturn.Replace("ẫ", "a");
                fileNameReturn = fileNameReturn.Replace("ậ", "a");
                fileNameReturn = fileNameReturn.Replace("í", "i");
                fileNameReturn = fileNameReturn.Replace("ì", "i");
                fileNameReturn = fileNameReturn.Replace("ỉ", "i");
                fileNameReturn = fileNameReturn.Replace("ĩ", "i");
                fileNameReturn = fileNameReturn.Replace("ị", "i");
                fileNameReturn = fileNameReturn.Replace("ý", "y");
                fileNameReturn = fileNameReturn.Replace("ỳ", "y");
                fileNameReturn = fileNameReturn.Replace("ỷ", "y");
                fileNameReturn = fileNameReturn.Replace("ỹ", "y");
                fileNameReturn = fileNameReturn.Replace("ỵ", "y");
                fileNameReturn = fileNameReturn.Replace("ó", "o");
                fileNameReturn = fileNameReturn.Replace("ò", "o");
                fileNameReturn = fileNameReturn.Replace("ỏ", "o");
                fileNameReturn = fileNameReturn.Replace("õ", "o");
                fileNameReturn = fileNameReturn.Replace("ọ", "o");
                fileNameReturn = fileNameReturn.Replace("ô", "o");
                fileNameReturn = fileNameReturn.Replace("ố", "o");
                fileNameReturn = fileNameReturn.Replace("ồ", "o");
                fileNameReturn = fileNameReturn.Replace("ổ", "o");
                fileNameReturn = fileNameReturn.Replace("ỗ", "o");
                fileNameReturn = fileNameReturn.Replace("ộ", "o");
                fileNameReturn = fileNameReturn.Replace("ơ", "o");
                fileNameReturn = fileNameReturn.Replace("ớ", "o");
                fileNameReturn = fileNameReturn.Replace("ờ", "o");
                fileNameReturn = fileNameReturn.Replace("ở", "o");
                fileNameReturn = fileNameReturn.Replace("ỡ", "o");
                fileNameReturn = fileNameReturn.Replace("ợ", "o");
                fileNameReturn = fileNameReturn.Replace("ú", "u");
                fileNameReturn = fileNameReturn.Replace("ù", "u");
                fileNameReturn = fileNameReturn.Replace("ủ", "u");
                fileNameReturn = fileNameReturn.Replace("ũ", "u");
                fileNameReturn = fileNameReturn.Replace("ụ", "u");
                fileNameReturn = fileNameReturn.Replace("ư", "u");
                fileNameReturn = fileNameReturn.Replace("ứ", "u");
                fileNameReturn = fileNameReturn.Replace("ừ", "u");
                fileNameReturn = fileNameReturn.Replace("ử", "u");
                fileNameReturn = fileNameReturn.Replace("ữ", "u");
                fileNameReturn = fileNameReturn.Replace("ự", "u");
                fileNameReturn = fileNameReturn.Replace("é", "e");
                fileNameReturn = fileNameReturn.Replace("è", "e");
                fileNameReturn = fileNameReturn.Replace("ẻ", "e");
                fileNameReturn = fileNameReturn.Replace("ẽ", "e");
                fileNameReturn = fileNameReturn.Replace("ẹ", "e");
                fileNameReturn = fileNameReturn.Replace("ê", "e");
                fileNameReturn = fileNameReturn.Replace("ế", "e");
                fileNameReturn = fileNameReturn.Replace("ề", "e");
                fileNameReturn = fileNameReturn.Replace("ể", "e");
                fileNameReturn = fileNameReturn.Replace("ễ", "e");
                fileNameReturn = fileNameReturn.Replace("ệ", "e");
                fileNameReturn = fileNameReturn.Replace("đ", "d");
                fileNameReturn = fileNameReturn.Replace("--", "-");
            }
            return fileNameReturn;
        }
        #endregion
    }

    public class YearFinance
    {
        public int Display { get; set; }
        public YearFinance()
        {
        }
        public static List<YearFinance> GetAllToList()
        {
            List<YearFinance> list = new List<YearFinance>();
            for (int i = AppGlobal.DateBegin; i <= AppGlobal.DateEnd; i++)
            {
                YearFinance model = new YearFinance();
                model.Display = i;
                list.Add(model);
            }
            return list;
        }
    }
    public class MonthFinance
    {
        public int Display { get; set; }
        public MonthFinance()
        {
        }
        public static List<MonthFinance> GetAllToList()
        {
            List<MonthFinance> list = new List<MonthFinance>();
            for (int i = 1; i <= 12; i++)
            {
                MonthFinance model = new MonthFinance();
                model.Display = i;
                list.Add(model);
            }
            return list;
        }
    }
}
