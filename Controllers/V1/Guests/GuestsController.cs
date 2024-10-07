using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Guests;

    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController(IGuestRepository guestRepository) : ControllerBase
    {
        protected readonly IGuestRepository _guestRepository = guestRepository;
    }
