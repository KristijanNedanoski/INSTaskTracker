using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSTaskTracker.Models
{
    public class Project
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserID { get; set; }
        [Required, StringLength(100), Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Required, Display(Name = "Estimate Time")]
        public int ETime { get; set; }
        [Display(Name = "Real Time")]
        public int RTime { get; set; }
        [StringLength(10000), Display(Name = "Description"),
        DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required, StringLength(100), Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [StringLength(100), Display(Name = "End Date")]
        public string EndDate { get; set; }


        public virtual ICollection<Assignment> Assignments { get; set; }

        [ForeignKey("Devid ")]
        public virtual ICollection<Developer> Developers { get; set; }
    }
}