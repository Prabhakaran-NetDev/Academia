using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Feedback
    {
        public int FeedbackID { get; set; }

        public int? CourseID { get; set; }

        public int? UserID { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }

        public DateTime FeedbackDate { get; set; }
    }
}
