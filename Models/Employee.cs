using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Models;
[Table("employees")]
public class Employee
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
    [Column("password")]
    public string Password { get; set; }

    public Employee(string firstName, string lastName, string email, string identificationNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentificationNumber = identificationNumber;
        Password = password;
    }
}
