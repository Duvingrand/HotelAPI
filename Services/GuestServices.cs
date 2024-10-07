using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_BrayanFelipeRodriguezMosquera.Data;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Services
{
    public class GuestServices : IGuestRepository
    {
private readonly MyDBContext _context;

    public GuestServices(MyDBContext context)
    {
        _context = context;
    }

        public async Task Add(Guest guest)
        {
            
        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "El huesped no puede ser nulo.");
        }

        try
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el huesped a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el huesped.", ex);
        }
        }

        public async Task<bool> CheckExistence(int id)
        {
            try
        {
            return await _context.Guests.AnyAsync(v => v.Id == id);
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el huesped a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al agregar el huesped.", ex);
        }
        }

        public async Task Delete(int id)
        {
        var vehicle = await _context.Guests.FindAsync(id);
        if (vehicle != null)
        {
            _context.Guests.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetById(int id)
        {
            return await _context.Guests.FindAsync(id);
        }

        public async Task<IEnumerable<Guest>> GetByKeyword(string keyword)
        {
             if (string.IsNullOrWhiteSpace(keyword))
        {
            return await GetAll();
        }

        return await _context.Guests.Where(
            g => g.Email.Contains(keyword) || 
            g.IdentificationNumber.Contains(keyword) || 
            g.PhoneNumber.Contains(keyword) || 
            g.FirstName.Contains(keyword) || 
            g.LastName.Contains(keyword)).ToListAsync();
        }

        public async Task Update(Guest guest)
        {
            if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "El huesped no puede ser nulo.");
        }

        try
        {
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al actualizar el huesped en la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un error inesperado al actualizar el huesped.", ex);
        }
        }
    }
}