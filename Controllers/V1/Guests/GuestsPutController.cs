using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.DTOs;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("guests")]
    public class GuestsPutController(IGuestRepository guestRepository) : GuestsController(guestRepository)
    {
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GuestDTO updatedGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkGuest = await _guestRepository.CheckExistence(id);
            if (checkGuest == false)
            {
                return NotFound();
            }

            var guest = await _guestRepository.GetById(id);

            if (guest == null)
            {
                return NotFound();
            }

            guest.FirstName = updatedGuest.FirstName;
            guest.LastName = updatedGuest.LastName;
            guest.Email = updatedGuest.Email;
            guest.IdentificationNumber = updatedGuest.IdentificationNumber;
            guest.PhoneNumber = updatedGuest.PhoneNumber;

            await _guestRepository.Update(guest);
            return NoContent();
        }
    }
}