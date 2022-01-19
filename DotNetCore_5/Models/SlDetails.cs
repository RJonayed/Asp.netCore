using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class SlDetails
    {
        [Key]
        public int SlDetailsID { get; set; }
        public int SlNO { get; set; }
        public int ClassId { get; set; }
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int BranchId { get; set; }
        public virtual ApplicationFrom ApplicationFrom { get; set; }
        public virtual Class Class { get; set; }
        public virtual Selection Selection { get; set; }
        public virtual School School { get; set; }
        public virtual Branch Branch { get; set; }
       
    }
}
