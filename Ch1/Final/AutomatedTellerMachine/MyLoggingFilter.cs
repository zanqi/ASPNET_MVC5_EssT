using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine
{
    public class MyLoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            Logger.LogRequest(request.UserHostAddress);
            filterContext.HttpContext.Response.AppendHeader("UserHostAddress", request.UserHostAddress);
            base.OnActionExecuted(filterContext);
        }

    }

    internal class Logger
    {
        internal static void LogRequest(string userHostAddress)
        {
            Console.WriteLine($"User Performed an Action: {userHostAddress}");
        }
    }
}