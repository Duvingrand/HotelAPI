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
    public class BookingServices : IBookingRepository
    {
        private readonly MyDBContext _context;

        public BookingServices(MyDBContext context)
        {
            _context = context;
        }

        public async Task Add(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking), "El empleado no puede ser nulo.");
            }

            try
            {
                await _context.Bookings.AddAsync(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al agregar el empleado  a la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al agregar el empleado ", ex);
            }
        }
        

        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Bookings.AnyAsync(v => v.Id == id);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al agregar el empleado a la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al agregar el empleado.", ex);
            }
        }

        public async Task Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllByIdentificationNumber(int identificationNumber)
        {
            return await _context.Bookings.Where(
                b => b.GuestId == identificationNumber).ToListAsync();
        }

        public async Task<Booking?> GetById(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task Update(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking), "El empleado no puede ser nulo.");
            }

            try
            {
                _context.Entry(booking).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al actualizar el empleado en la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al actualizar el empleado.", ex);
            }
        }
    }
}