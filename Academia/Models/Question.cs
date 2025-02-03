using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Question
    {
        public int QuestionID { get; set; }

        public int? AssessmentID { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        [StringLength(50)]
        public string QuestionType { get; set; }

        public int Points { get; set; }
    }
}
