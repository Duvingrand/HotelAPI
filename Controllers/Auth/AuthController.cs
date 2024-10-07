using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_BrayanFelipeRodriguezMosquera.Models;
using PruebaNET_BrayanFelipeRodriguezMosquera.Repositories;
using RepasoJWT.Config;
using RepasoJWT.DTOs.Requests;

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Controllers.Auth;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
         protected readonly IEmployeeRepository servicios;

    public AuthController(IEmployeeRepository userRepository)
    {
        servicios = userRepository;
    }

    // metodo que me genera un JWT
    [HttpPost]
    public async Task<IActionResult> GenerateToken(Employee user)
    {
        var token = JWT.GenerateJwtToken(user);

        return Ok($"ACA ESTA SU TOKEN: {token}");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto data)
    {
        var user = await servicios.GetByEmail(data.Email); 

        if (user == null)
            return BadRequest("El usuario no existe");

        if (user.Password != data.Password)
            return BadRequest("Contraseña incorrecta");

        var token = JWT.GenerateJwtToken(user);

        return Ok($"ACA ESTA SU TOKEN: {token}");

    }
    }
