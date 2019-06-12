using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzarias.Extra.WebApi.Domains;
using Pizzarias.Extra.WebApi.Interfaces;
using Pizzarias.Extra.WebApi.Repositorios;

namespace Pizzarias.Extra.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PizzariasController : ControllerBase
    {
        private IPizzariaRepositorio PizzariaRepositorio { get; set; }
        public PizzariasController()
        {
            PizzariaRepositorio = new PizzariaRepositorio();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                int idrecebido = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string tipousuario = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value.ToString();

                List<Pizzaria> listaPizzarias = PizzariaRepositorio.ListarPizzarias(idrecebido, tipousuario);
                return Ok(listaPizzarias);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Post(Pizzaria pizzaria)
        {
            try
            {
                PizzariaRepositorio.Cadastrar(pizzaria);
                return Ok(new { mensagem = "Pizzaria Cadastrada" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{pizzariaId}")]
        public IActionResult GetUsuario(int IdPizzaria)
        {
            try
            {
                Pizzaria pizzariaBuscada = PizzariaRepositorio.BuscarPizzaria(IdPizzaria);

                if (pizzariaBuscada == null)
                {
                    return NotFound(new { mensagem = "Pizzaria não encontrada" });
                }

                return Ok(pizzariaBuscada);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}