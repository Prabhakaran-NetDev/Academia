using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Assignment
    {
        public int AssignmentID { get; set; }

        public int? CourseID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int MaxPoints { get; set; }
    }
}
