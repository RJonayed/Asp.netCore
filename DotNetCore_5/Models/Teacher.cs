using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Display(Name ="Teacher Name")]
        [Required, MaxLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string TeacherName { get; set; }
        [Display(Name = "Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$")]
        public string Email { get; set; }
        [Display(Name = "Mobile")]
        [Required, MaxLength(11, ErrorMessage = "Mobile No can't exceed 11 characters")]
        public string ContNumber { get; set; }
        [Display(Name = "Join Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime joinDate { get; set; }   
        [Required]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

    }
}
