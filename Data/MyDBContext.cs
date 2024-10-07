using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Seeders;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Data;

public class MyDBContext : DbContext
{
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        RoomTypeSeed.Seed(modelBuilder);
    }
}
