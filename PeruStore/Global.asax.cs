using System;
using System.Web;
using System.Web.Routing;

namespace PeruStore
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                //Exception ex = Server.GetLastError();
                //if (((HttpException)ex).GetHttpCode() == 404)
                //    Response.Redirect("/Error/Error404.aspx");
                //else
                //    Response.Redirect("/Error/Error500.aspx");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}