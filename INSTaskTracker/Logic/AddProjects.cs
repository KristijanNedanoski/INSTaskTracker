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
        public bool AddProject(string PName, int eTime, string Des, DateTime sDate, string User)
        {
            var myProject = new Models.Project
            {
                ProjectName = PName,
                ETime = eTime,
                Description = Des,
                UserID = User,
                StartDate = sDate.Date,
                IsFinished = false
            };
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                // Add project to DB.
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