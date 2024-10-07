using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Rooms;

[ApiController]
[Route("api/v1/rooms")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("rooms")]
public class RoomsGetController(IRoomRepository roomRepository) : RoomsController(roomRepository)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAll()
    {
        var rooms = await _roomRepository.GetAll();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetById(int id)
    {
        var room = await _roomRepository.GetById(id);
        if (room == null)
        {
            return NotFound();
        }
        return room;
    }

    [HttpGet("avaliable")]
    public async Task<ActionResult<IEnumerable<Room>>> GetAvaliable()
    {
        var rooms = await _roomRepository.Avaliable();
        return Ok(rooms);
    }

    [HttpGet("occupied")]
    public async Task<ActionResult<IEnumerable<Room>>> GetOccupied()
    {
        var rooms = await _roomRepository.Occupied();
        return Ok(rooms);
    }

    [HttpGet("status")]
    public async Task<ActionResult<IEnumerable<string>>> GetStatus()
    {
        var roomsMessage = await _roomRepository.Status();
        return Ok(roomsMessage);
    }

}
