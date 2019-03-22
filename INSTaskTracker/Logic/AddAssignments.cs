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
    public class AddAssignments
    {
        public bool AddTask(string AName, string eTime, string Des, DateTime sDate, Guid project)
        {
            var myAssignment = new Models.Assignment
            {
                AssignmentName = AName,
                ETime = Convert.ToInt32(eTime),
                Description = Des,
                ProjectID = project,
                StartDate = sDate.Date,
                IsFinished = false
            };
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                // Adding Assignment estimated time project entry in the database
                var myProject = (from c in _db.Projects
                                 where c.ProjectID == project
                                 select c).FirstOrDefault();
                myProject.ETime += Convert.ToInt32(eTime);
                // Add assignments to DB.
                _db.Assignments.Add(myAssignment);
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