using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace INSTaskTracker.Models
{
    public class ProjectAssignmentDatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            GetProjects().ForEach(c => context.Projects.Add(c));
            GetAssignments().ForEach(p => context.Assignments.Add(p));
        }
        private static List<Project> GetProjects()
        {
            var projects = new List<Project>
            {
            };
            return projects;
        }
        private static List<Assignment> GetAssignments()
        {
            var assignments = new List<Assignment>
            {
            };
            return assignments;
        }
    }
}