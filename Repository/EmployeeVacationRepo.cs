using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnoManagment.Context;
using TechnoManagment.Models;
using TechnoManagment.Services;

namespace TechnoManagment.Repository
{
    public class EmployeeVacationRepo(MyDBContext myDBContext) : IGenaricRepository<EmployeeVacation>
    {
        private readonly MyDBContext _myDBContext = myDBContext;

        public async Task<bool> CreateVacation(EmployeeVacation employeeVacation)
        {
            await _myDBContext.AddAsync(employeeVacation);
            return await _myDBContext.SaveChangesAsync() > 0;
        }
        public async Task<List<EmployeeVacation>> GetAll()
        {
            return await _myDBContext.EmployeeVacations.AsNoTracking().ToListAsync();
        }

        public async Task<EmployeeVacation> GetById(string id)
        {
            return await _myDBContext.EmployeeVacations.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}