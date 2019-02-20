using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSTaskTracker.Models
{
    public class Developer : ApplicationUser
    {
        [ForeignKey("Projid ")]
        public virtual ICollection<Project> Projects { get; set; }
    }

    
}