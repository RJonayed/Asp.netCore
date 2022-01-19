using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Students
    {
        [Key]
        public int ApplicantId { get; set; }
        [Display(Name = "Applicant Name")]
        [Required, StringLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string ApplicantName { get; set; }
    }
}
