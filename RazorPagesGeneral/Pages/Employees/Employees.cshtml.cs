using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepozitory _db;
        public EmployeesModel(IEmployeeRepozitory db)
        {
            _db = db;           
        }

        public IEnumerable<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = _db.GetAllEmployees();
        }
    }
}
