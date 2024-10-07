using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_BrayanFelipeRodriguezMosquera.Data;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Services;

public class RoomServices : IRoomRepository
{
    private readonly MyDBContext _context;

    public RoomServices(MyDBContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Room>> Avaliable()
    {
        return await _context.Rooms.Where(r => r.Availability == true).ToListAsync();
    }

    public async Task<bool> CheckExistence(int id)
    {
        try
        {
            return await _context.Rooms.AnyAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error de la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el vehículo.", ex);
        }
    }

    public async Task<IEnumerable<Room>> GetAll()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetById(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<IEnumerable<Room>> Occupied()
    {
        return await _context.Rooms.Where(r => r.Availability == false).ToListAsync();
    }

    public async Task<IEnumerable<string>> Status()
    {
        var occupiedCount = await _context.Rooms.CountAsync(r => !r.Availability);

        var notOccupiedCount = await _context.Rooms.CountAsync(r => r.Availability);

        var result = new List<string>
        {
            $"Habitaciones ocupadas: {occupiedCount}",
            $"Habitaciones no ocupadas: {notOccupiedCount}"
        };

        return result;
    }

    public async Task Update(Room room)
    {
        try
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error  en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado.", ex);
        }
    }
}
