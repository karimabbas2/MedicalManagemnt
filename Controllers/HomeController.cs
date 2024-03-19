using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechnoManagment.Helper;
using TechnoManagment.Models;
using TechnoManagment.Services;
using TechnoManagment.ViewModel;

namespace TechnoManagment.Controllers;

public class HomeController(IGenaricRepository<EmployeeVacation> genaricRepository) : Controller
{
    private readonly IGenaricRepository<EmployeeVacation> _genaricRepository = genaricRepository;

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CreateVacation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateVacation(VacationViewModel dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var ReturningDate = CalculateReturningDate.Calculate(dto.VDateTo);

        EmployeeVacation employeeVacation = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name,
            Title = dto.Title,
            Department = dto.Department,
            VDateFrom = DateOnly.FromDateTime(dto.VDateFrom),
            VDateTo = DateOnly.FromDateTime(dto.VDateTo),
            Returning = ReturningDate,
            CountedDays = (dto.VDateTo - dto.VDateFrom).Days,
            Notes = dto.Notes,
        };
        var result = await _genaricRepository.CreateVacation(employeeVacation);
        if (result)
        {
            ViewBag.Alert = "Created Successfully";
            ModelState.Clear();
            return View();
        }
        ModelState.AddModelError("", "Faild To Save, try again");
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> AllEmolyeesVacation()
    {
        try
        {
            return View(await _genaricRepository.GetAll());
        }
        catch (Exception ex)
        {
            ViewBag.Alert = ex.Message;
            return View(ViewBag.Alert);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        try
        {
            return View(await _genaricRepository.GetById(id));
        }
        catch (Exception ex)
        {
            ViewBag.Alert = ex.Message;
            return View(ViewBag.Alert);
        }
    }
}
