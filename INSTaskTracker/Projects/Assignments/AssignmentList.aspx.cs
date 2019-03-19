using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker.Models;
using Microsoft.AspNet.Identity;

namespace INSTaskTracker.Projects.Assignments
{
    public partial class AssignmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Assignment> GetAssignments()
        {
            string List = Request.QueryString["list"];
            Guid projectid = Guid.Parse(Request.QueryString["projectID"]);
            var _db = new ApplicationDbContext();
            IQueryable<Assignment> query = _db.Assignments;
            string user = HttpContext.Current.User.Identity.GetUserId();
            var myproject = (from c in _db.Projects
                             where c.ProjectID == projectid
                             select c).FirstOrDefault();
            if (List == "Current")
            {
                query = query.Where(p => p.ProjectID == projectid && p.IsFinished == false && p.UserID != null);
                return query;
            }
            else if (List == "Planned")
            {
                query = query.Where(p => p.ProjectID == projectid && p.IsFinished == false && p.UserID == null);
                return query;
            }
            else if (List == "Mine")
            {
                query = query.Where(p => p.ProjectID == projectid && p.IsFinished == false && p.UserID == user);
                return query;
            }
            else
            {
                query = query.Where(p => p.ProjectID == projectid && p.IsFinished == true);
                return query;
            }
        }
    }
}