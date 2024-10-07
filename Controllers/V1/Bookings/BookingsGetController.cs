using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Bookings;

[ApiController]
[Route("api/v1/bookings")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("bookings")]
public class BookingsGetController(IBookingRepository bookingRepository) : BookingsController(bookingRepository)
{
    [HttpGet("/search/{identification_number}")]
    public async Task<ActionResult<IEnumerable<Booking>>> GetAll(int identification_number)
    {
        var bookings = await _bookingRepository.GetAllByIdentificationNumber(identification_number);
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetById(int id)
    {
        var booking = await _bookingRepository.GetById(id);
        if (booking == null)
        {
            return NotFound();
        }
        return booking;
    }



}
