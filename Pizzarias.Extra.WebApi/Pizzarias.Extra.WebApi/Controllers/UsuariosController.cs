using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzarias.Extra.WebApi.Interfaces;
using Pizzarias.Extra.WebApi.Repositorios;
using Pizzarias.Extra.WebApi.Domains;
using Microsoft.AspNetCore.Authorization;

namespace Pizzarias.Extra.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepositorio UsuarioRepositorio { get; set; }

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepositorio();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> ListarUsuarios = UsuarioRepositorio.ListarUsuarios();
                return Ok(ListarUsuarios);
            }catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok(new { mensagem = "Usuário Cadastrado com sucesso!"});
            }catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Put(Usuario usuario)
        {
            try
            {
                UsuarioRepositorio.Alterar(usuario);
                return Ok(new {mensagem="Usuário alterado com sucesso!" });
            }catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (PizzariasContext ctx = new PizzariasContext())
            {
                ctx.Usuario.Remove(ctx.Usuario.Find(id));
            }
            return Ok(new {mensagem="Usuário removido com sucesso." });
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{usuarioId}")]
        public IActionResult GetUsuario(int usuarioId)
        {
            try
            {
                Usuario usuarioBuscado = UsuarioRepositorio.BuscarUsuario(usuarioId);

                if (usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado" });
                }

                return Ok(usuarioBuscado);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}