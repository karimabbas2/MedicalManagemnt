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
            switch (dayName)
            {
                case DayOfWeek.Thursday:
                    return DateOnly.FromDateTime(dateOnly.AddDays(3));
                default:
                    return DateOnly.FromDateTime(dateOnly);
            }
        }
    }
}