using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLessons.Services
{
    public class MockEmployeeRepozitory : IEmployeeRepozitory
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepozitory()
        {
            _employeeList = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0,
                    Name = "Mary",
                    Email = "Mary@mail.com",
                    PhotoPath = "avatar.png",
                    Department = Dept.HR
                },
                                new Employee()
                {
                    Id = 1,
                    Name = "John",
                    Email = "John@mail.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.IT
                },
                                                new Employee()
                {
                    Id = 2,
                    Name = "Bill",
                    Email = "Bill@mail.com",
                    PhotoPath = "avatar3.png",
                    Department = Dept.Payroll
                },
                                                                                                new Employee()
                {
                    Id = 3,
                    Name = "Rom",
                    Email = "Rom@mail.com",
                    PhotoPath = "avatar4.png",
                    Department = Dept.Payroll
                },
                                                                                                                                                new Employee()
                {
                    Id = 4,
                    Name = "Mik",
                    Email = "Mik@mail.com",
                    PhotoPath = "avatar5.png",
                    Department = Dept.Payroll
                },
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee? Delete(int id)
        {
            Employee employeeToDelete = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employeeToDelete != null)
            {
                _employeeList.Remove(employeeToDelete);
            }
            return employeeToDelete;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee? GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }
            return employee;
        }
    }
}
