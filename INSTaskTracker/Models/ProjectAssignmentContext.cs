﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using INSTaskTracker;

namespace INSTaskTracker.Models
{
    public class ProjectAssignmentContext : DbContext
    {
        public ProjectAssignmentContext() : base("INSTaskTracker")
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        //public DbSet<ApplicationUserManager> AspNetUserRoles { get; set; }
    }
}