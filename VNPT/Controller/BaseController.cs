using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNPT.Data.Enum;
using VNPT.Data.Helpers;
using VNPT.Data.Models;
using VNPT.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace VNPT.Controllers
{
    public class BaseController : Controller, IActionFilter
    {

        public BaseController()
        {

        }
        public int RequestUserID
        {
            get
            {
                int.TryParse(Request.Cookies["UserID"]?.ToString(), out int result);
                return result;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
