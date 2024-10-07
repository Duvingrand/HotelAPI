using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

public interface IGuestRepository
{
    Task<IEnumerable<Guest>> GetAll();
    Task<Guest?> GetById(int id);
    Task<IEnumerable<Guest>> GetByKeyword(string keyword);
    Task Add(Guest guest);
    Task Update(Guest guest);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}
