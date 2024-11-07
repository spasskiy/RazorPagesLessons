using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepozitory _employeeRepozitory;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmployeeRepozitory employeeRepozitory, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepozitory = employeeRepozitory;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = _employeeRepozitory.GetEmployee(id.Value);
            }
            else
                Employee = new Employee();

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Employee.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    Employee.PhotoPath = ProcessUploadedFile();
                }

                if(Employee.Id > 0)
                {
                    Employee = _employeeRepozitory.Update(Employee);
                    TempData["SuccessMessage"] = $"Сотрудник {Employee.Name} успешно обновлён.";
                }
                else
                {
                    Employee = _employeeRepozitory.Add(Employee);
                    TempData["SuccessMessage"] = $"Сотрудник {Employee.Name} добавлен.";
                }


                return RedirectToPage("Employees");
            }

            return Page();
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Спасибо что включили оповещения.";
            }
            else
            {
                Message = "Оповещения отключены.";
            }
            Employee = _employeeRepozitory.GetEmployee(id);
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
