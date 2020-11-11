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
    public class ProductController : BaseController
    {       
        private readonly IProductRepository _productRepository;
        private readonly IProductConfigRepository _productConfigRepository;
        public ProductController(IProductRepository productRepository, IProductConfigRepository productConfigRepository) : base()
        {
            _productRepository = productRepository;
            _productConfigRepository = productConfigRepository;
        }       
    }
}
