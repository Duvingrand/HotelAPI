using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.DTOs;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Employees
{
    [ApiController]
[Route("api/v1/employees")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("employees")]
 public class GuestsPutController(IEmployeeRepository employeeRepository) : EmployeesController(employeeRepository)
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeDTO updatedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkEmployee = await _employeeRepository.CheckExistence(id);
            if (checkEmployee == false)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.IdentificationNumber = updatedEmployee.IdentificationNumber;
            employee.Password = updatedEmployee.Password;

            await _employeeRepository.Update(employee);
            return NoContent();
        }
    }
}