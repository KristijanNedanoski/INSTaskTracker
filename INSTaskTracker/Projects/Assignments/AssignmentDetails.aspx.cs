using System;
<<<<<<< HEAD
using System.Collections;
using System.IO;
=======
using System.Collections.Generic;
>>>>>>> 10dac3dd1b4789e8141fdb58353ede7de36e1cb6
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
using INSTaskTracker;
using INSTaskTracker.Models;
using System.Web.ModelBinding;
using System.Web.Hosting;
=======
>>>>>>> 10dac3dd1b4789e8141fdb58353ede7de36e1cb6

namespace INSTaskTracker.Projects.Assignments
{
    public partial class AssignmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD
        public IQueryable<Models.Assignment> GetAssignment([QueryString("assignmentID")] Guid? assignmentId)
        {
            var _db = new INSTaskTracker.Models.ApplicationDbContext();
            IQueryable<Models.Assignment> query = _db.Assignments;
            if (assignmentId.HasValue)
            {
                query = query.Where(p => p.AssignmentID == assignmentId);
            }
            else
            {
                query = null;
            }
            return query;
        }
        public string GetDeveloperName(string developerid)
        {
            var _db = new ApplicationDbContext();
            IQueryable<ApplicationUser> query = _db.Users;
            ApplicationUser myUser = (from c in _db.Users
                                      where c.Id == developerid
                                      select c).FirstOrDefault();
            return myUser.UserName;
        }
=======
>>>>>>> 10dac3dd1b4789e8141fdb58353ede7de36e1cb6
    }
}