using CinemaMagic.Entidade;
using CinemaMagic.Servico;
using Microsoft.AspNetCore.Mvc;

namespace CinemaMagic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeServico _contexto;

        public FilmeController(IFilmeServico contexto)
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
            bool existeFilme = _contexto.ExisteFilme(id);

            if (existeFilme)
            {
                return Ok(await _contexto.SelecionarPorID(id));
            }

            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }


        [HttpPost]
        public async Task<IActionResult> Incluir(FilmeEntidade entFilme)
        {
            await _contexto.Incluir(entFilme);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(FilmeEntidade entFilme)
        {
            bool existeFilme = _contexto.ExisteFilme(entFilme.ID);

            if (existeFilme)
            {
                await _contexto.Alterar(entFilme);
                return Ok();
            }

            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int filmeID)
        {
            bool existeFilme = _contexto.ExisteFilme(filmeID);

            if (existeFilme)
            {
                await _contexto.Excluir(filmeID);
                return Ok();
            }
            return StatusCode(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }
    }
}