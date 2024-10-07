using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Models;
[Table("rooms")]
public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("room_number")]
    public required string RoomNumber { get; set; }
    //------------------------------------------------------
    [Column("room_type_id")]
    public int RoomTypeID { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(RoomTypeID))]
    public RoomType RoomType { get; set; }
    //------------------------------------------------------
    [Column("price_per_night")]
    public double PricePerNight { get; set; }
    [Column("availability")]
    public bool Availability { get; set; }
    [Column("max_occupancy_people")]
    public int MaxOccupancyPeople { get; set; }

    public Room(string roomNumber, int roomTypeID)
    {
        double pricePerNight;
        int maxOccupancyPeople;

        switch (roomTypeID)
        {
            case 1:
                pricePerNight = 50;
                maxOccupancyPeople = 1;
                break;

            case 2:
                pricePerNight = 80;
                maxOccupancyPeople = 2;
                break;

            case 3:
                pricePerNight = 150;
                maxOccupancyPeople = 2;
                break;

            case 4:
                pricePerNight = 200;
                maxOccupancyPeople = 4;
                break;

            default:
                pricePerNight = 0;
                maxOccupancyPeople = 0;
                break;
        }

        RoomNumber = roomNumber;
        RoomTypeID = roomTypeID;
        PricePerNight = pricePerNight;
        Availability = true;
        MaxOccupancyPeople = maxOccupancyPeople;
    }
}
