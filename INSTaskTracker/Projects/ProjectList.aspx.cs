﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INSTaskTracker.Models;
using Microsoft.AspNet.Identity;

namespace INSTaskTracker
{
    public partial class ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Project> GetProjects()
        {
            var _db = new ApplicationDbContext();
            IQueryable<Project> query = _db.Projects;
            IQueryable<Assignment> assignments = _db.Assignments;
            string user;
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                query = query.Where(p => p.IsFinished == false);
                return query;
            }
            else if (HttpContext.Current.User.IsInRole("Developer"))
            {
                //Filtering projects for developers
                user = HttpContext.Current.User.Identity.GetUserId();
                assignments = assignments.Where(x => x.UserID == user);
                query = query.Where(p => assignments.Contains(p.Assignments.FirstOrDefault()));
                query = query.Where(p => p.IsFinished == false);
                return query;
            }
            else
            {
                //Filtering projects for clients
                user = HttpContext.Current.User.Identity.GetUserId();
                query = query.Where(p => p.UserID == user);
                query = query.Where(p => p.IsFinished == false);
                return query;
            }
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