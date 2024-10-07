using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("guests")]
public class GuestsGetController(IGuestRepository guestRepository) : GuestsController(guestRepository)
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Guest>>> GetAll()
    {
        var guests = await _guestRepository.GetAll();
        return Ok(guests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetById(int id)
    {
        var guest = await _guestRepository.GetById(id);
        if (guest == null)
        {
            return NotFound();
        }
        return guest;
    }

    [HttpGet("search/{keyword}")]
    public async Task<ActionResult<IEnumerable<Guest>>> SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("La palabra clave no puede estar vacía.");
        }

        var vehicles = await _guestRepository.GetByKeyword(keyword);

        if (!vehicles.Any())
        {
            return NotFound("No se encontraron huespedes que coincidan con la palabra clave proporcionada.");
        }

        return Ok(vehicles);
    }

}
