using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;

    public interface IBookingRepository
    {
    Task<IEnumerable<Booking>> GetAllByIdentificationNumber(string identificationNumber);
    Task<Booking?> GetById(int id);
    Task Add(Booking booking);
    Task Update(Booking booking);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
        
    }
