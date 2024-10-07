using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Rooms
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController(IRoomRepository roomRepository) : ControllerBase
{
    protected readonly IRoomRepository _roomRepository = roomRepository;
}
}