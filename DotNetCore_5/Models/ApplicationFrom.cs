using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Models
{
    public class ApplicationFrom
    {
        [Key]
        public int SlNO { get; set; }
        [Display(Name = "Applicant Id")]
        public int ApplicantId { get; set; }
        [Display(Name = "Applicant Name")]
        [Required, StringLength(30, ErrorMessage = "Name can't exceed 30 characters")]
        public string ApplicantName { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        [Display(Name = "Birth Registration No")]
        public int BirthRegistrationNo { get; set; }
        [Display(Name ="Image")]
        public string ImageUrl { get; set; }
        [Display (Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mothrs Name")]       
        public string MothrsName { get; set; }
        [Display (Name ="Mobile No")]
        [Required]
        public int ContNo { get; set; }
        [Required]
        public string Address { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicationDate { get; set; }
        public bool IsSelect { get; set; }
        public int ClassId { get; set; }
        public int BranchId { get; set; }
        public int SchoolId { get; set; }
        public int GroupId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual School School { get; set; }
        public virtual GroupInfo GroupInfo { get; set; }

    }
}
