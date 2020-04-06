using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentEmailId { get; set; }

        [Required]
        public string StudentMobileNo { get; set; }

        [Required]
        public Boolean FeesPaid { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
    }
}
