using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Models;
[Table("bookings")]
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    //--------------------------------------------
    [Column("room_id")]
    public int RoomId { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }
    //--------------------------------------------
    [Column("guest_id")]
    public int GuestId { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(GuestId))]
    public Guest Guest { get; set; }
    //--------------------------------------------
    [Column("employee_id")]
    public int EmployeeId { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; }
    //--------------------------------------------
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    [Column("end_date")]
    public DateTime? EndDate { get; set; }



    public Booking(int roomId, int guestId, int employeeId, DateTime startDate, DateTime? endDate)
    {
        RoomId = roomId;
        GuestId = guestId;
        EmployeeId = employeeId;
        StartDate = startDate;
        EndDate = endDate;
    }
}
