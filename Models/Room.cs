using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Models;
[Table("rooms")]
public class Room
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("room_number")]
    public required string RoomNumber { get; set; }
    [Column("room_type_id")]
    public int RoomTypeID { get; set; }
    [Column("price_per_night")]
    public double PricePerNight { get; set; }
    [Column("availability")]
    public bool Availability { get; set; }
    [Column("max_occupancy_people")]
    public int MaxOccupancyPeople { get; set; }

}
