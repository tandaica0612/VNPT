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


namespace VNPT.Controllers
{
    public class ProductConfigController : BaseController
    {
        private readonly IProductConfigRepository _productConfigRepository;
        public ProductConfigController(IProductConfigRepository productConfigRepository) : base()
        {

            _productConfigRepository = productConfigRepository;
        }
    }
}
