using System.Data.SqlClient;
using VNPT.Data.DataTransferObject;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace VNPT.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly VNPTContext _context;

        public ProductRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
