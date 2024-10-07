using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAll();
    Task<Room?> GetById(int id);
    Task<IEnumerable<Room>> Avaliable();
    Task<IEnumerable<Room>> Occupied();
    Task<IEnumerable<string>> Status();
    Task<bool> CheckExistence(int id);
    Task Update(Room room);

}