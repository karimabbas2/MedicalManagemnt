using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnoManagment.Models;

namespace TechnoManagment.Context
{
    public class MyDBContext(DbContextOptions<MyDBContext> options) : DbContext(options)
    {
        // public override int SaveChanges()
        // {
        //     var Entities = from e in ChangeTracker.Entries()
        //                    where e.State == EntityState.Added
        //                    select e.Entity;

        //     foreach (var Entity in Entities)
        //     {
        //         ValidationContext validationContext = new(Entity);
        //         Validator.ValidateObject(Entity, validationContext, true);
        //     }

        //     return base.SaveChanges();
        // }
        public DbSet<EmployeeVacation> EmployeeVacations { get; set; }
    }
}