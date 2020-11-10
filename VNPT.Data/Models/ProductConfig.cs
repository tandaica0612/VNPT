﻿using System;
using System.Collections.Generic;

namespace VNPT.Data.Models
{
    public partial class ProductConfig : BaseModel
    {
        public int? ProductID { get; set; }
        public int? ConfigID { get; set; }
        public decimal? Value { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string URL { get; set; }
    }
}
