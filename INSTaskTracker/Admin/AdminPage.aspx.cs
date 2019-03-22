using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker.Logic;
using INSTaskTracker.Models;

namespace INSTaskTracker.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string projectAction = Request.QueryString["ProjectAction"];
            if (projectAction == "add")
            {
                LabelAddStatus.Text = "Project added!";
            }
            if (projectAction == "remove")
            {
                //LabelAddStatus.Text = "Project removed!";
            }
        }
        protected void AddProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Add project to DB.
                AddProjects projects = new AddProjects();
                string userid = ProjectClient.SelectedValue;
                DateTime startDate; // = Convert.ToDateTime(AddProjectStartDate.Text);
                var dateParseResult = DateTime.TryParse(AddProjectStartDate.Text, out startDate);
               // if (!dateParseResult) throw new Exception("Kristijan"); 
                var _db = new ApplicationDbContext();
                var myUser = (from c in _db.Users
                              where c.Id == userid
                              select c).FirstOrDefault();
                if (myUser != null)
                {
                    projects.AddProject(AddProjectName.Text, 0,
                    AddProjectDescription.Text, startDate.Date, myUser.Id);
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0,
                    Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProjectAction=add");
                }
            }
            catch (Exception ex)
            {
                LabelAddStatus.Text = ex.Message;
            }
        }

        public IQueryable GetProjects()
        {
            var _db = new INSTaskTracker.Models.ApplicationDbContext();
            IQueryable query = _db.Projects;
            return query;
        }
        public IQueryable GetClients()
        {
            var _db = new ApplicationDbContext();
            IQueryable<ApplicationUser> query = _db.Users;
            var client = (from c in _db.Roles
                          where c.Name == "Client"
                          select c).FirstOrDefault();
            query = query.Where(p => p.Roles.Select(y => y.RoleId).Contains(client.Id));
            return query;
        }
        /*protected void RemoveProjectButton_Click(object sender, EventArgs e)
        {
            using (var _db = new INSTaskTracker.Models.ApplicationDbContext())
            {
                string projectName = DropDownRemoveProject.SelectedValue;
                var myItem = (from c in _db.Projects
                              where c.ProjectName == projectName
                              select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Projects.Remove(myItem);
                    _db.SaveChanges();
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0,
                    Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate project.";
                }
            }
        }*/
    }
}