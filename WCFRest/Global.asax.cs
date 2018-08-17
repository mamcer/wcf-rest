using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace WCFRest
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("api", new WebServiceHostFactory(), typeof(Service.Service)));
        }
    }
}