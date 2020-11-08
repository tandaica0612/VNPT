using System;
using System.Collections.Generic;

namespace VNPT.Data.Models
{
    public partial class Config : BaseModel
    {
        public string GroupName { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? SortOrder { get; set; }
    }
}
