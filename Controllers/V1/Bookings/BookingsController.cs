using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Bookings
{
    [ApiController]
    [Route("api/[controller]")]    
    public class BookingsController(IBookingRepository bookingRepository) : ControllerBase
    {
        protected readonly IBookingRepository _bookingRepository = bookingRepository;
    }
}