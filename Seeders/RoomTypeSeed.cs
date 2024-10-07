using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Seeders
{
    public class RoomTypeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>().HasData(
                new
                {
                    Id = 1, 
                    Name = "Habitación Simple",
                    Description = "Una acogedora habitación básica con una cama individual, ideal para viajeros solos."
                },
                new
                {
                    Id = 2,
                    Name = "Habitación Doble",
                    Description = "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos."
                },
                new
                {
                    Id = 3,
                    Name = "Suite",
                    Description = "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad."
                },
                new
                {
                    Id = 4,
                    Name = "Habitación Familiar",
                    Description = "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda."
                }
            );
        }
    }
}
