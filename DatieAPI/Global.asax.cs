using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;
using System.Web.SessionState;

namespace DatieAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new AddCustomHeaderFilter());
        }
     

    }
    public class AddCustomHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Credentials", "true");
            actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Headers","x-requested-with, Authorization");
            actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Methods","OPTIONS, GET, HEAD, POST");
        }
    }
}
