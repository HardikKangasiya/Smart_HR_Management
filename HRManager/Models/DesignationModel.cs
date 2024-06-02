using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManager.Models
{
    public class DesignationModel
    {
        [Key]
        public int DesignationID { get; set; }
        [Required]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; }
    }
}