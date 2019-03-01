using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INSTaskTracker.Models
{
    public class Assignment
    {
        [ScaffoldColumn(false)]
        [Key]
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AssignmentID { get; set; }
        [Required]
        public Guid ProjectID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required, StringLength(100), Display(Name = "Assignment Name")]
        public string AssignmentName { get; set; }
        [StringLength(10000), Display(Name = "Description"),
        DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required, Display(Name = "Estimated Time")]
        public int ETime { get; set; }
        [Display(Name = "Real Time")]
        public int RTime { get; set; }
    }
}