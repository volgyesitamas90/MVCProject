using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ServiceStack.OrmLite;
using ServiceStack.WebHost.Endpoints;
using Funq;

namespace WebSiteNewsService
{

    public class Global : System.Web.HttpApplication
    {
        public class WebSiteAppHost : AppHostBase
        {
            public WebSiteAppHost()
                : base("WebSite", typeof(SubmissionService).Assembly)
            { }

            public override void Configure(Container container)
            {
                var dbConnectionFactory =
                    new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/data.txt"),
                        SqliteDialect.Provider);
                container.Register<IDbConnectionFactory>(dbConnectionFactory);
                container.RegisterAutoWired<DataRepository>();
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new WebSiteAppHost().Init();
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