using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.ViewModels
{
    public class CreateRoleViewModel
    {
        [Display(Name ="Role")]
        [Required]
        public string RoleName { get; set; }
    }
}
