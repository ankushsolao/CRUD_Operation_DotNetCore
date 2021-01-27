using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter First Name")]  
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Designation")]
        public string Designation { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Enter Mobile Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        public string Department { get; set; }

        public string Address { get; set; }

        public string City { get; set; }       

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
