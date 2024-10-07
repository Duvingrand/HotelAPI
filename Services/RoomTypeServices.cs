using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_BrayanFelipeRodriguezMosquera.Data;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Services;

    public class RoomTypeServices : IRoomTypeRepository
    {
            private readonly MyDBContext _context;

    public RoomTypeServices(MyDBContext context)
    {
        _context = context;
    }

        public async Task<IEnumerable<RoomType>> GetAll()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType?> GetById(int id)
        {
            return await _context.RoomTypes.FindAsync(id);
        }
    }
