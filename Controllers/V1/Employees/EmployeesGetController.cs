using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Employees
{
    [ApiController]
[Route("api/v1/employees")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("employees")]
    public class EmployeesGetController(IEmployeeRepository employeeRepository) : EmployeesController(employeeRepository)
    {
        
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
    {
        var employees = await _employeeRepository.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }
        return employee;
    }
    }
}