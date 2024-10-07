using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

public interface IRoomTypeRepository
{
    Task<IEnumerable<RoomType>> GetAll();
    Task<RoomType?> GetById(int id);
}
