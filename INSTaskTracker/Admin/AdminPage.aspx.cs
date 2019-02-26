using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker.Models;
using INSTaskTracker.Logic;
using System.Web.ModelBinding;

namespace INSTaskTracker.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected global::System.Web.UI.WebControls.Label LabelAddStatus;
        protected global::System.Web.UI.WebControls.Label LabelRemoveStatus;
        protected global::System.Web.UI.WebControls.DropDownList DropDownRemoveProject;
        protected global::System.Web.UI.WebControls.TextBox AddProjectName;
        protected global::System.Web.UI.WebControls.TextBox AddProjectDescription;
        protected global::System.Web.UI.WebControls.TextBox AddProjectETime;
        protected global::System.Web.UI.WebControls.TextBox AddProjectSDate;
        protected global::System.Web.UI.WebControls.DropDownList ProjectUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Project added!";
            }
            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "Project removed!";
            }
        }
        protected void AddProjectButton_Click(object sender, EventArgs e)
        {
            // Add project to DB.
            AddProjects projects = new AddProjects();
            string userName = AddProjectClient.Text;
            bool addSuccess = true;
            var _db = new ApplicationDbContext();
            var myUser = (from c in _db.Users
                                      where c.UserName == userName
                                      select c).FirstOrDefault();
            if (myUser == null)
            {
                addSuccess = false;
            }
            
            if (addSuccess)
            {
                projects.AddProject(AddProjectName.Text, AddProjectEstimatedTime.Text,
                AddProjectDescription.Text, AddProjectStartDate.Text, myUser.Id);
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0,
                Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?ProjectAction=add");
            }
            else
            {
                LabelAddStatus.Text = "Unable to add new project to database.";
            }
        }
        public IQueryable GetProjects()
        {
            var _db = new INSTaskTracker.Models.ApplicationDbContext();
            IQueryable query = _db.Projects;
            return query;
        }
        protected void RemoveProjectButton_Click(object sender, EventArgs e)
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
        }
        /*public IQueryable GetClients()
        {
            var _db = new INSTaskTracker.Models.ProjectAssignmentContext();
            IQueryable<ApplicationUser> query = _db.AspNetUsers;
            return query;
        }*/

        /* public IQueryable GetClients()
         {
             var _db = new UserContext();
             IQueryable<ApplicationUser> query = _db.AspNetUsers;
             //query = query.Where(p => p.Roles.Select(y => y.RoleId).Contains("f7b4f6a1-5bcf-4f82-ab9d-2d78167a51b6"));
             return query;
         }
         <asp:DropDownList ID="ProjectUser" runat="server"
                     SelectMethod="GetClients" AppendDataBoundItems="true"
                     DataTextField="UserName" DataValueField="Id">
                 </asp:DropDownList>

          */
    }
}