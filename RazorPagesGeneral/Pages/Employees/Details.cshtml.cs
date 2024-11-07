using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepozitory _employeeRepozitory;
        public DetailsModel(IEmployeeRepozitory employeeRepozitory)
        {
            _employeeRepozitory = employeeRepozitory;
        }

        public Employee? Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepozitory.GetEmployee(id);

            if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
