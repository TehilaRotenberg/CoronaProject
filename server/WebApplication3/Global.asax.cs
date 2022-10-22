using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApplication3
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
		protected void Application_BeginRequest()
		{
			if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
			{
				HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
				HttpContext.Current.Response.AddHeader(" Access-Control-Allow-Headers", "Content-Type, Accept");
				HttpContext.Current.Response.StatusCode = 200;
				HttpContext.Current.Response.End();
			}
		}

	}
}
