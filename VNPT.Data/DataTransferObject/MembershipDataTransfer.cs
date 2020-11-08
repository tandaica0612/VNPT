using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VNPT.Data.Models;

namespace VNPT.Data.DataTransferObject
{
    public class MembershipDataTransfer
    {
        public int ID { get; set; }
        public string FullName { get; set; }
    }
}
