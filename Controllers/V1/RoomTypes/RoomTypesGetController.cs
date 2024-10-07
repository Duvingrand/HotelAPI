using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.RoomTypes;

[ApiController]
[Route("api/v1/room_types")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("room_types")]
public class RoomTypesGetController(IRoomTypeRepository roomTypeRepository) : RoomTypesController(roomTypeRepository)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomType>>> GetAll()
    {
        var roomTypes = await _roomTypeRepository.GetAll();
        return Ok(roomTypes);
    }

     [HttpGet("{id}")]
    public async Task<ActionResult<RoomType>> GetById(int id)
    {
        var roomTypes = await _roomTypeRepository.GetById(id);
        if (roomTypes == null)
        {
            return NotFound();
        }
        return roomTypes;
    }
}
