using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoManagment.Helper
{
    public static class CalculateReturningDate
    {
        public static DateOnly Calculate(DateTime dateOnly)
        {
            var dayName = dateOnly.DayOfWeek;
            return dayName switch
            {
                DayOfWeek.Thursday => DateOnly.FromDateTime(dateOnly.AddDays(3)),
                _ => DateOnly.FromDateTime(dateOnly),
            };
        }
    }
}