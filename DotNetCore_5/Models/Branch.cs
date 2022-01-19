using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Display(Name = "Branch")]
        [Required, MaxLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string BranchName { get; set; }
        [Display(Name = "Address")]
        [Required, MaxLength(150, ErrorMessage = "Address can't exceed 150 characters")]
        public string BranchLocation { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
