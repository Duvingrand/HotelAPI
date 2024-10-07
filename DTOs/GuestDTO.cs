using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.DTOs;

public class GuestDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [StringLength(50, ErrorMessage = "El correo electrónico no puede exceder los 50 caracteres.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "El número de identificación es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de identificación no puede exceder los 50 caracteres.")]
    public required string IdentificationNumber { get; set; }

    [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de teléfono no puede exceder los 50 caracteres.")]
    public required string PhoneNumber { get; set; }
    public DateOnly? BirthDate { get; set; }
}
