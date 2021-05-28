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
    public class DesejoController : ControllerBase
    {

        private IDesejoRepository _DesejoRepository { get; set; }

        public DesejoController()
        {
            _DesejoRepository = new DesejoRepository();

        }

        [HttpGet]
        public IActionResult Listar()
        {

            try
            {
                return Ok(_DesejoRepository.ListarDesejos());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);

            }

        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id) {

            try
            {

                return Ok(_DesejoRepository.BuscarDesejo(id));

            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(Desejo novoDesejo)
        {

            if (_DesejoRepository.BuscarDesejoNome(novoDesejo.Descricao) == null)
            {

                _DesejoRepository.CadastrarDesejo(novoDesejo);

                return StatusCode(201);

            }

            return BadRequest("Não é possível cadastrar dois desejos iguais");

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) {

            Desejo desejo = new Desejo();

            desejo = _DesejoRepository.BuscarDesejo(id);

            if (desejo != null)
            {

            _DesejoRepository.DeletarDesejo(id);

            return StatusCode(204);

            }

                return NotFound("Esse Desejo Não Existe ou Ja Foi Apagado !!!");

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, DesejoViewModel desejoatt)
        {

            try
            {
                Desejo desejo = new Desejo();

                desejo = _DesejoRepository.BuscarDesejo(id);

                if (desejo != null)
                {

                    desejo = new Desejo { IdUsuario = desejoatt.IdUsuario, Descricao = desejoatt.Descricao };

                    _DesejoRepository.AtualizarDesejo(id, desejo);

                    return StatusCode(204);

                }

                return NotFound("Id nao encontrado");

            }
            catch (Exception exception)
            {

                return BadRequest(exception);

            }
        }

    }
}
