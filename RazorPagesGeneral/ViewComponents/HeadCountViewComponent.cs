using Microsoft.AspNetCore.Mvc;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepozitory _employeeRepozitory;

        public HeadCountViewComponent(IEmployeeRepozitory employeeRepozitory)
        {
            _employeeRepozitory = employeeRepozitory;
        }
        public IViewComponentResult Invoke(Dept? dept = null)
        {
            var result = _employeeRepozitory.EmployeeCountByDept(dept);
            return View(result);
        }
   
    }
}
