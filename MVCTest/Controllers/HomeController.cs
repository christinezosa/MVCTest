using Microsoft.AspNetCore.Mvc;
using MVCTest.Data;
using MVCTest.Models;
using MVCTest.ViewModels;

namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCTestContext _context;

        public HomeController(MVCTestContext context)
        {
            _context = context;
        }

        // Generates the web page for the application
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // Returns a JSON object of employees and their total shift hours per month
        [HttpGet]
        public JsonResult RefreshList(string? searchValue)
        {
            var listData = new List<EmployeeShiftsViewModel>();

            foreach (Employee employee in GetEmployeesList(searchValue))
            {
                listData.Add(new EmployeeShiftsViewModel { Employee = employee, TotalHours = GetTotalShiftHoursList(GetShiftsList(employee.EmployeeId)) });
            }

            return Json(listData);
        }

        // Returns a collection of employees
        private ICollection<Employee> GetEmployeesList(string? searchValue)
        {
            var employee = _context.Employee
                           .Select(e => new Employee
                           {
                               EmployeeId = e.EmployeeId,
                               FirstName = e.FirstName,
                               Surname = e.Surname
                           });

            if (!String.IsNullOrEmpty(searchValue))
            {
                employee = employee.Where(e => e.FirstName.Contains(searchValue) || e.Surname.Contains(searchValue));
            }

            return employee.ToList();
        }

        // Returns a collection of shifts
        private ICollection<Shift> GetShiftsList(int? employeeId)
        {
            var shifts = from s in _context.Shift
                         join ews in _context.EmployeeWorksShift on s.ShiftId equals ews.ShiftId
                         where ews.EmployeeId == employeeId
                         select s;

            return shifts.ToList();
        }
        
        // Returns a collection of shifts and their hours
        private ICollection<ShiftHours> GetTotalShiftHoursList(ICollection<Shift> Shifts)
        {
            return Shifts.GroupBy(s => s.ShiftMonthInt)
                         .Select(s => new ShiftHours 
                                 { 
                                    MonthId = s.First().ShiftMonthInt,
                                    MonthName = s.First().ShiftMonth,
                                    Hours = s.Sum(s => s.ShiftHours) 
                                 }).ToList();
        }
    }
}