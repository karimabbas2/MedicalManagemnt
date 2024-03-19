using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnoManagment.Services
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<bool> CreateVacation(T t);
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
    }
}