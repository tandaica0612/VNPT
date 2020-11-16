using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Models;

namespace VNPT.Models
{
    public class BaseViewModel
    {
        public PhieuYeuCau PhieuYeuCau { get; set; }
        public List<Config> ListLoaiBaiViet { get; set; }
        public List<Product> ListProduct { get; set; }       
    }
}
