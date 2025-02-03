using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Lesson
    {
        public int LessonID { get; set; }

        public int? CourseID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(255)]
        public string VideoURL { get; set; }

        public int OrderIndex { get; set; }
    }
}
