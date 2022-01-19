using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        [Display(Name = "School")]
        [Required, MaxLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string SchoolName { get; set; }
        [Display(Name = "Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$")]
        public string Email { get; set; }
        [Required, MaxLength(25, ErrorMessage = "Adrres can't exceed 25 characters")]
        public string Address { get; set; }
        [Display(Name = "Establish Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EstDate { get; set; }
        
    }
}
