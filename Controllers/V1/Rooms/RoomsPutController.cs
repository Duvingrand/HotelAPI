using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.V1.Rooms
{
    [ApiController]
    [Route("api/v1/rooms")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("rooms")]

    public class RoomsPutController : RoomsController
    {
        public RoomsPutController(IRoomRepository roomRepository) : base(roomRepository)
        {
        }

        [HttpPut("{id}/availability")]
        public async Task<ActionResult<string>> UpdateRoomAvailability(int id)
        {
            try
            {
                // Busca la habitación por ID
                var room = await _roomRepository.GetById(id);
                if (room == null)
                {
                    return NotFound();
                }

                // Alterna la disponibilidad
                room.Availability = !room.Availability;

                // Guarda los cambios
                await _roomRepository.Update(room);

                // Devuelve un mensaje con el nuevo estado de disponibilidad
                return Ok(new { Availability = room.Availability });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al actualizar la disponibilidad: " + ex.Message);
            }
        }
    }

}