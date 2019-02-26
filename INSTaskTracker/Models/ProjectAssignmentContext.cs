using System;
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
        
    }
}