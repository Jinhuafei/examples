using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.SessionState;

namespace JeffsSample
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType(BuildManager.GetCompiledType("/EditCustomer.aspx"));
            var container = containerBuilder.Build();
            var autofacAdapter = new AutofacAdapter(container);
            HttpRuntime.WebObjectActivator = autofacAdapter;
            HostingEnvironment.RegisterObject(autofacAdapter);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}