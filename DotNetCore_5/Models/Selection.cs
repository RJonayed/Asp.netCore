using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class Selection
    {
        [Key]
        public int Id { get; set; }
        public string Position { get; set; }
        public int SlNO { get; set; }
        public int ApplicantId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ApplicationFrom ApplicationFrom { get; set; }
    }
}
