using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.DTOs;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Bookings;

    [ApiController]
[Route("api/v1/bookings")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("bookings")]
public class BookingsPostController(IBookingRepository bookingRepository) : BookingsController(bookingRepository)
    {
        [HttpPost]
    public async Task<ActionResult<Booking>> Create(BookingDTO inputBooking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newBooking = new Booking(inputBooking.RoomId, inputBooking.GuestId, inputBooking.EmployeeId, inputBooking.StartDate, inputBooking.EndDate);

        await _bookingRepository.Add(newBooking);

        return Ok(newBooking);
    }
    }
