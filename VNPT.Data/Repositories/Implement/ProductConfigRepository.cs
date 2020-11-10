using VNPT.Data.DataTransferObject;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VNPT.Data.Repositories
{
    public class ProductConfigRepository : Repository<ProductConfig>, IProductConfigRepository
    {
        private readonly VNPTContext _context;

        public ProductConfigRepository(VNPTContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
