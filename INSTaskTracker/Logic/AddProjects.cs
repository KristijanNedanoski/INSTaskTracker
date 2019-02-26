using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INSTaskTracker.Models;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Entity.Validation;

namespace INSTaskTracker.Logic
{
    public class AddProjects
    {
        public bool AddProject(string PName, string eTime, string Des, string sDate, string User)
        {
            var myProject = new Models.Project();
            myProject.ProjectName = PName;
            myProject.ETime = Convert.ToInt32(eTime);
            myProject.Description = Des;
            myProject.UserID = User;
            myProject.StartDate = sDate;
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                // Add file to DB.
                _db.Projects.Add(myProject);
                try
                {
                    _db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
            // Success.
            return true;
        }
    }
}