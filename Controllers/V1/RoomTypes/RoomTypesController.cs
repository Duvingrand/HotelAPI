using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.RoomTypes;

    [ApiController]
    [Route("api/[controller]")]
public class RoomTypesController(IRoomTypeRepository roomTypeRepository) : ControllerBase
{
    protected readonly IRoomTypeRepository _roomTypeRepository = roomTypeRepository;
}

