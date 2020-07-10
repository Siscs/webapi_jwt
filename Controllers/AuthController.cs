using System;
using lxwebapi.Models;
using lxwebapi.Repositories;
using lxwebapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lxwebapi.Controllers
{
    [ApiController]
    [Route("v1/Auth")]
    public class AuthController: ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<dynamic> GetToken([FromBody] Usuario usuario ) {

            var usuarioAuth = UserRepository.Get(usuario.Nome, usuario.Password);

            if(usuarioAuth == null) return NotFound(new { Message = "Usuário inválido "});
            
            var token = TokenService.GenerateToken(usuarioAuth);

            return Ok(new 
            { 
                Usuario = usuario.Nome,
                Token = token
            });

        }

        [HttpGet]
        [Route("user")]
        public string GetUsuarioAuth()
        {
            var claims = User.Claims;
            var roles = User.IsInRole("nome_role");
            return $"Usuario Autenticado: {User.Identity.Name} - {DateTime.Now.ToString()}"; 


        }

    }
}