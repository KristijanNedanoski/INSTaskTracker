using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using INSTaskTracker.Models;
using INSTaskTracker.Logic;

namespace INSTaskTracker
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            Database.SetInitializer(new ProjectAssignmentDatabaseInitializer());

            // Create the administrator role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.CreateAdmin();

            // Create the developer and client roles
            RoleActions Developer = new RoleActions();
            Developer.CreateDeveloper();
            RoleActions Client = new RoleActions();
            Client.CreateClient();
        }
    }
}