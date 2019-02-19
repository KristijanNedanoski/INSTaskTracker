using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using INSTaskTracker;

namespace INSTaskTracker.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("INSTaskTracker")
        {
        }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        //public DbSet<ApplicationUserManager> AspNetUserRoles { get; set; }
    }
}