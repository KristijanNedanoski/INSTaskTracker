using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker;
using INSTaskTracker.Models;
using System.Web.ModelBinding;
using System.Web.Hosting;

namespace INSTaskTracker.Projects
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var _db = new INSTaskTracker.Models.ApplicationDbContext())
            {
                if (HttpContext.Current.User.IsInRole("Client"))
                {
                    AddTaskLink.Visible = false;
                    MyAssignmentsLink.Visible = false;
                }
            }
        }
        public IQueryable<Models.Project> GetProject([QueryString("projectID")] Guid? projectId)
        {
            var _db = new INSTaskTracker.Models.ApplicationDbContext();
            IQueryable<Models.Project> query = _db.Projects;
            if (projectId.HasValue)
            {
                query = query.Where(p => p.ProjectID == projectId);
            }
            else
            {
                query = null;
            }
            return query;
        }
        public string GetClientName(string clientid)
        {
            var _db = new ApplicationDbContext();
            IQueryable<ApplicationUser> query = _db.Users;
            ApplicationUser myUser = (from c in _db.Users
                                      where c.Id == clientid
                                      select c).FirstOrDefault();
            return myUser.UserName;
        }
    }
}