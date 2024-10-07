using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.DTOs
{
    public class BookingDTO
    {
        [Required(ErrorMessage = "El ID de la habitación es obligatorio.")]
        public required int RoomId { get; set; }

        [Required(ErrorMessage = "El ID del huésped es obligatorio.")]
        public required int GuestId { get; set; }

        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        public required int EmployeeId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}