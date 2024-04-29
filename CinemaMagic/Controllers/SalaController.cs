using CinemaMagic.Entidade;
using CinemaMagic.Servico;
using Microsoft.AspNetCore.Mvc;

namespace CinemaMagic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaServico _contexto;

        public SalaController(ISalaServico contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Selecionar()
        {
            var result = await _contexto.Selecionar();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelecionarPorID(int id)
        {
            bool existeSala = _contexto.ExisteSala(id);

            if (existeSala)
            {
                return Ok(await _contexto.SelecionarPorID(id));
            }

            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }

        [HttpGet("/filme/{filmeID}")]
        public async Task<IActionResult> SelecionarSalaPorFilme(int filmeID)
        {
            bool existeFilme = _contexto.ExisteFilme(filmeID);

            if (existeFilme)
            {
                return Ok(await _contexto.SelecionarSalaPorFilme(filmeID));
            }

            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }


        [HttpPost]
        public async Task<IActionResult> Incluir(SalaEntidade entSala)
        {
            bool existeFilme = _contexto.ExisteFilme(entSala.FilmeID);

            if (existeFilme)
            {
                await _contexto.Incluir(entSala);
                return Ok();

            }

            return StatusCode(StatusCodes.Status404NotFound, "É Preciso Incluir um Filme existente no banco.");
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(SalaEntidade entSala)
        {
            bool existeSala = _contexto.ExisteSala(entSala.ID);

            if (existeSala)
            {
                await _contexto.Alterar(entSala);
                return Ok();
            }

            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int salaID)
        {
            bool existeSala = _contexto.ExisteSala(salaID);

            if (existeSala)
            {
                await _contexto.Excluir(salaID);
                return Ok();
            }
            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }
    }
}