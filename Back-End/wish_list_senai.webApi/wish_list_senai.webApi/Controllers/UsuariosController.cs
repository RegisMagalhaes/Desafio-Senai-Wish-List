using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list_senai.webApi.Domains;
using wish_list_senai.webApi.Interfaces;
using wish_list_senai.webApi.Repositories;
using wish_list_senai.webApi.ViewModels;

namespace wish_list_senai.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Um Status code 200 - Ok e uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca um usuário através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Um status code 200 - Ok e um usuário encontrado, se não encontrar retorna NotFound</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                if (_usuarioRepository.BuscarPorEmail(novoUsuario.Email) == null)
                {
                    _usuarioRepository.Cadastrar(novoUsuario);

                    return StatusCode(201);
                }

                return BadRequest("Esse usuário já está cadastrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UsuarioViewModel usuarioAtualizado)
        {
            try
            {
                if (_usuarioRepository.BuscarPorEmail(usuarioAtualizado.Email) != null)
                {
                    return BadRequest("E-mail já existente!");
                }

                Usuario user = _usuarioRepository.BuscarPorId(id);

                if (user != null)
                {
                    user = new Usuario
                    {
                        Email = usuarioAtualizado.Email,
                        Senha = usuarioAtualizado.Senha
                    };

                    _usuarioRepository.Atualizar(id, user);

                    return StatusCode(204);
                }

                return NotFound("Usuário não encontrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta um usuário existente através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_usuarioRepository.BuscarPorId(id) != null)
                {
                    _usuarioRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Usuário não encontrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
