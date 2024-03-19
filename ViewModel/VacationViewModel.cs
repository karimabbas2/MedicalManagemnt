using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechnoManagment.CustomValidation;
using TechnoManagment.Models;

namespace TechnoManagment.ViewModel
{
    public class VacationViewModel
    {
        [Required(ErrorMessage = "Employee Name is Requierd"), Display(Name = "Employee Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Title Is Requierd")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Department Is Requierd")]
        public Department Department { get; set; }

        [Required, Display(Name = "Vacation Date From")]
        [DataType(DataType.Date)]
        [DateComareValidation(ErrorMessage = "Vacation Date Can't be less than today'date")]
        public DateTime VDateFrom { get; set; }

        [Required, Display(Name = "Vacation Date To")]
        [DataType(DataType.Date)]
        [DateCompare("VDateFrom", ErrorMessage = "Vacation Date to Can't be less than Vaction Date From")]
        public DateTime VDateTo { get; set; }
        public string? Notes { get; set; }
    }
}