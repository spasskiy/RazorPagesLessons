﻿using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLessons.Services
{
    public  interface IEmployeeRepozitory
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee? GetEmployee(int id);
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
        Employee? Delete(int id);
    }
}
