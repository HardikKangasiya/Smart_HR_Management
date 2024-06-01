using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManager.Models
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
    }
}