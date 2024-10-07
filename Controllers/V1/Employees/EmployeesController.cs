using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Employees
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IEmployeeRepository employeeRepository) : ControllerBase
    {
        protected readonly IEmployeeRepository _employeeRepository = employeeRepository;
    }
}