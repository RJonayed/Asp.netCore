using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Display(Name ="Class Name")]
        [Required, MaxLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string ClassName { get; set; }
        //public int BranchId { get; set; }  add  
    }
}
