using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INSTaskTracker;
using INSTaskTracker.Models;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Entity.Validation;

namespace INSTaskTracker.Logic
{
    public class AddProject
    {
        public bool AddProjects(string pName, int eTime, string Desc, Guid User, string sDate)
        {
            var myProject = new Models.Project
            {
                ProjectName = pName,
                ETime = eTime,
                Description = Desc,
                UserID = User,
                StartDate = sDate
            };

            using (ProjectAssignmentContext _db = new ProjectAssignmentContext())
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