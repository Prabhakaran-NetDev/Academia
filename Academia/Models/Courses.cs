using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Courses
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int? InstructorID { get; set; }

        public decimal Price { get; set; }

        public int DurationWeeks { get; set; }

        [Column(TypeName = "date")]        
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [NotMapped]
        public string InstructorName { get; set; }
    }
}
