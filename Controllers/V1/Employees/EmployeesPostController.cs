using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.DTOs;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Employees;

    [ApiController]
[Route("api/v1/employees")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("employees")]
    public class GuestsPostController(IEmployeeRepository employeeRepository) : EmployeesController(employeeRepository)
{
    [HttpPost]
    public async Task<ActionResult<Employee>> Create(EmployeeDTO inputGuest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newEmployee = new Employee(inputGuest.FirstName, inputGuest.LastName, inputGuest.Email, inputGuest.IdentificationNumber, inputGuest.Password);

        await _employeeRepository.Add(newEmployee);

        return Ok(newEmployee);
    }
}
