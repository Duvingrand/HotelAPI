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
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    public required string FirstName { get; set; }
    [Column("last_name")]
    public required string LastName { get; set; }
    [Column("email")]
    public required string Email { get; set; }
    [Column("identification_number")]
    public required string IdentificationNumber { get; set; }
    [Column("password")]
    public required string Password { get; set; }
}
