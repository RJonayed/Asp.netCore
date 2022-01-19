using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Display(Name = "Subject")]
        [Required, StringLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string SubjectName { get; set; }
        [Display(Name = "Subject Code")]
        public int SubjectCode { get; set; }
        [Display(Name ="Subject Marks")]
        public int ExamMark { get; set; }
        [Display(Name ="Group")]
        public int GroupsId { get; set; }
        public virtual GroupInfo GroupInfo { get; set; }
    }
}
