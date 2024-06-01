using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManager.Models
{
    public class HolidayModel
    {
        [Key]
        public int HolidayID { get; set; }

        [Required(ErrorMessage = "Holiday Name is required")]
        [Display(Name = "Holiday Name")]
        public string HolidayName { get; set; }

        [Required(ErrorMessage = "Holiday Date is required")]
        [Display(Name = "Holiday Date")]
        [DataType(DataType.DateTime)]
        public DateTime HolidayDate { get; set; }
    }
}