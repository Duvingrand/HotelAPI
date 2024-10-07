using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("guests")]
public class GuestsDeleteController(IGuestRepository guestRepository) : GuestsController(guestRepository)
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicle = await _guestRepository.CheckExistence(id);
        if (vehicle == false)
        {
            return NotFound();
        }

        await _guestRepository.Delete(id);

        return NoContent();
    }
}
