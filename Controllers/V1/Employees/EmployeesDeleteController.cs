using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Employees;

[ApiController]
[Route("api/v1/employees")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("employees")]
public class EmployeesDeleteController(IEmployeeRepository employeeRepository) : EmployeesController(employeeRepository)
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _employeeRepository.CheckExistence(id);
        if (employee == false)
        {
            return NotFound();
        }

        await _employeeRepository.Delete(id);

        return NoContent();
    }
}