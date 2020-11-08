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

namespace VNPT.CRM.Controllers
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
            string controller = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            string action = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;
            if (this.RequestUserID > 0)
            {
            }
            else
            {
                if (((controller.Equals("Membership")) && (action.Equals("Login"))) || ((controller.Equals("Home")) && (action.Equals("Index"))))
                {
                }
                else
                {
                    context.Result = new RedirectToRouteResult(
                       new RouteValueDictionary
                       {
                            {"controller", "Home"},
                            {"action", "Index"}
                       }
                    );
                }
            }
        }
    }
}
