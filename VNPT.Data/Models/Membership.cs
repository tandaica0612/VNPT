using VNPT.Data.Helpers;
using System;
using System.Collections.Generic;

namespace VNPT.Data.Models
{
    public partial class Membership : BaseModel
    {
        public int? CategoryID { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CitizenIdentification { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string GUICode { get; set; }
        public string TaxCode { get; set; }
        public int? ProvinceID { get; set; }
        public int? CityID { get; set; }
        public int? WardID { get; set; }
        public string MembershipCode { get; set; }
        public string ContactFullName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Image { get; set; }
        public void InitDefaultValue()
        {
            if (string.IsNullOrEmpty(this.GUICode))
            {
                this.GUICode = AppGlobal.InitGuiCode;
            }
        }
        public void EncryptPassword()
        {
            this.Password = SecurityHelper.Encrypt(this.GUICode, this.Password);
        }
        public void DecryptPassword()
        {
            this.Password = SecurityHelper.Decrypt(this.GUICode, this.Password);
        }
    }
}
