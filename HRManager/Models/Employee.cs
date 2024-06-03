using HRManager.CustomValidation;
using System;
using System.Collections.Generic;
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
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }
        
        [Required]
        [IntegerString(ErrorMessage = "Phone Number must be 10 digit number")]
        public string Phone { get; set; }
        
        [Required]
        public string Department { get; set; }
        
        [Required]
        public string Designation { get; set; }

        public byte[] ProfilePicture { get; set; }

    }
}