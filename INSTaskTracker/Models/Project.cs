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
        [Required]
        public string UserID { get; set; }
        [Required, StringLength(100), Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Required, Display(Name = "Estimate Time")]
        public int ETime { get; set; }
        [Display(Name = "Real Time")]
        public int? RTime { get; set; }
        [StringLength(10000), Display(Name = "Description"),
        DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsFinished { get; set; }


        public virtual ICollection<Assignment> Assignments { get; set; }     
        public virtual ICollection<Developer> Developers { get; set; }
    }
}