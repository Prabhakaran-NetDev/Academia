using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Answer
    {
        public int AnswerID { get; set; }

        public int? QuestionID { get; set; }

        [Required]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }
    }
}
