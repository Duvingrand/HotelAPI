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
    public class EmployeeServices : IEmployeeRepository
    {

        private readonly MyDBContext _context;

        public EmployeeServices(MyDBContext context)
        {
            _context = context;
        }
        public async Task Add(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "El empleado no puede ser nulo.");
            }

            try
            {
                await _context.Employees.AddAsync(employee);
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

        public async Task<Employee?> GetByEmail(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Employees.AnyAsync(v => v.Id == id);
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
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "El empleado no puede ser nulo.");
            }

            try
            {
                _context.Entry(employee).State = EntityState.Modified;
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