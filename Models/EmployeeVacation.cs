using System.ComponentModel.DataAnnotations;

namespace TechnoManagment.Models
{
    public class EmployeeVacation
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public Department Department { get; set; }

        [DataType(DataType.Date)]
        public DateOnly SubmissionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Date)]
        public DateOnly VDateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateOnly VDateTo { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Returning { get; set; }
        public int CountedDays { get; set; }
        public string? Notes { get; set; }

    }

}