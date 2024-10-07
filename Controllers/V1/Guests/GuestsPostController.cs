using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.DTOs;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("guests")]
public class GuestsPostController(IGuestRepository guestRepository) : GuestsController(guestRepository)
{
    [HttpPost]
    public async Task<ActionResult<Guest>> Create(GuestDTO inputGuest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newGuest = new Guest(inputGuest.FirstName, inputGuest.LastName, inputGuest.Email, inputGuest.IdentificationNumber, inputGuest.PhoneNumber, inputGuest.BirthDate);

        await _guestRepository.Add(newGuest);

        return Ok(newGuest);
    }
}
