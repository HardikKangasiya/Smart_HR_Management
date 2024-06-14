using HRManager.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManager.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }
        
        [Required]
        [PhoneNumber(ErrorMessage = "Phone Number must be 10 digit number")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        
        [Required]
        public string Department { get; set; }
        
        [Required]
        public string Designation { get; set; }

        [DisplayName("Profile Picture")]
        public byte[] ProfilePicture { get; set; }

    }
}