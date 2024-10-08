using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Models;
[Table("guests")]
public class Guest
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("identification_number")]
    public string IdentificationNumber { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    public Guest(string firstName, string lastName, string email, string identificationNumber, string phoneNumber, DateOnly? birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentificationNumber = identificationNumber;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }
}
