using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepozitory _employeeRepozitory;
        public DeleteModel(IEmployeeRepozitory employeeRepozitory)
        {
            _employeeRepozitory = employeeRepozitory;
        }
        
        [BindProperty]
        public Employee Employee { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepozitory.GetEmployee(id);

            if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Employee deletedEmployee = _employeeRepozitory.Delete(Employee.Id);
            if (deletedEmployee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Employees/Employees");
        }
    }
}
