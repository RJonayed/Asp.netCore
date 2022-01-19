using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class GroupInfo
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name = "Group Name")]
        [Required,StringLength(30,ErrorMessage = "Name can't exceed 30 characters")]
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
    }
}
