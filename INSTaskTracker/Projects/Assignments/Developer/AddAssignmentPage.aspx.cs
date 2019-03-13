using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker.Logic;
using INSTaskTracker.Models;

namespace INSTaskTracker.Projects.Assignments.Developer
{
    public partial class AddAssignmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string assignmentAction = Request.QueryString["AssignmentAction"];
            if (assignmentAction == "add")
            {
                LabelAddStatus.Text = "Assignment added!";
            }
            if (assignmentAction == "remove")
            {
                //LabelAddStatus.Text = "Project removed!";
            }
        }
        protected void AddAssignmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Add assignment to DB.
                AddAssignments assignments = new AddAssignments();
                Guid projectid = Guid.Parse(Project.SelectedValue);
                DateTime startDate; // = Convert.ToDateTime(AddProjectStartDate.Text);
                var dateParseResult = DateTime.TryParse(AddAssignmentStartDate.Text, out startDate);
                // if (!dateParseResult) throw new Exception("Kristijan");
                var _db = new ApplicationDbContext();
                var myProject = (from c in _db.Projects
                              where c.ProjectID == projectid
                              select c).FirstOrDefault();
                if (myProject != null)
                {
                    assignments.AddTask(AddAssignmentName.Text, AddAssignmentEstimatedTime.Text,
                    AddAssignmentDescription.Text, startDate.Date, myProject.ProjectID);
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0,
                    Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?AssignmentAction=add");
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
        /*public IQueryable GetClients()
         {
              var _db = new ApplicationDbContext();
              IQueryable<ApplicationUser> query = _db.Users;
              var client = (from c in _db.Roles
                            where c.Name == "Client"
                            select c).FirstOrDefault();
              query = query.Where(p => p.Roles.Select(y => y.RoleId).Contains(client.Id));
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
          }*/
    }
}