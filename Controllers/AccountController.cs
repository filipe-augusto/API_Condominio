using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Text.RegularExpressions;
using API_Condominio.Services;
using API_Condominio.ViewModel;
using API_Condominio.Data;
using API_Condominio.Models;
using API_Condominio.Extensions;
namespace API_Condominio.Controllers;

    [ApiController]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpPost("v1/login")] // new request 
        public IActionResult Login([FromServices] TokenService tokenService)
        {

            var token = tokenService.GenerateToken(null);
            //setar os objetos para nullo e matar o tokenservice. com isso o garbage collector vai levar ele da memoria

            return Ok(token);
        }

        [Authorize(Roles = "user")]
        [HttpGet("v1/user")]
        public IActionResult GetUser() => Ok(User.Identity.Name);


        [Authorize(Roles = "author")]
        [HttpGet("v1/author")]
        public IActionResult GetAuthor() => Ok(User.Identity.Name);


        [Authorize(Roles = "admin")]
        [HttpGet("v1/admin")]
        public IActionResult GetAdmin() => Ok(User.Identity.Name);

        [HttpPost("v1/accounts/")]
        public async Task<IActionResult> Post(
         [FromBody] RegisterViewModel model,
         [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
            };

            var password = PasswordGenerator.Generate(25);
            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    user = user.Email,
                    password
                }));
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já está cadastrado"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            }
        }
    }

