using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Submission
    {
        public int SubmissionID { get; set; }

        public int? AssignmentID { get; set; }

        public int? UserID { get; set; }

        public DateTime SubmissionDate { get; set; }

        public string Content { get; set; }

        public int? Grade { get; set; }
    }
}
