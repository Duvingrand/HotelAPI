using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Bookings;
    [ApiController]
    [Route("api/v1/bookings")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("bookings")]
    
 public class BookingsDeleteController(IBookingRepository bookingRepository) : BookingsController(bookingRepository)
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _bookingRepository.CheckExistence(id);
        if (employee == false)
        {
            return NotFound();
        }

        await _bookingRepository.Delete(id);

        return NoContent();
    }
}
