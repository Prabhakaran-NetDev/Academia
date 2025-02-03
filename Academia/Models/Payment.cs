using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public partial class Payment
    {
        public int PaymentID { get; set; }

        public int? UserID { get; set; }

        public int? CourseID { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; }
    }
}
