using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int? UserID { get; set; }

        public int? CourseID { get; set; }

        public DateTime EnrollmentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
