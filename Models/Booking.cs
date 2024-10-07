using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Models;
[Table("bookings")]
public class Booking
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("room_id")]
    public int RoomId { get; set; }
    [Column("guest_id")]
    public int GuestId { get; set; }
    [Column("employee_id")]
    public int EmployeeId { get; set; }
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    [Column("end_date")]
    public DateTime? EndDate { get; set; }
    [Column("total_cost")]
    public double TotalCost { get; set; }
}
