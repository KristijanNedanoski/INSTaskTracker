using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker.Models;
using Microsoft.AspNet.Identity;

namespace INSTaskTracker
{
    public partial class ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Project> GetProjects()
        {
            var _db = new ProjectAssignmentContext();
            IQueryable<Project> query = _db.Projects;
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                return query;
            }
            else if (HttpContext.Current.User.IsInRole("Developer"))
            {
                //Filtering projects for developers
                return query;
            }
            else
            {
                //Filtering projects for clients
                query = query.Where(p => p.UserID == HttpContext.Current.User.Identity.GetUserId());
                return query;
            }
        }
    }
}