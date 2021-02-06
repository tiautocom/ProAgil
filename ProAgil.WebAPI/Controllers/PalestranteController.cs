using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Entities;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId)
        {
            try
            {
                var results = await _repo.GetPalestranteByIdAsync(palestranteId, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !!!");
            }
        }


        // GET api/evento/5
        [HttpGet("getByName/{name}")]
        public async Task<IActionResult> GetAllPalestrantesAsyncByName(string name)
        {
            try
            {
                var results = await _repo.GetAllPalestrantesAsyncByName(name, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !!!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    // return Ok();
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !!!");
            }

            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(int PalestranteId, Evento model)
        {
            try
            {
                var palestrante = await _repo.GetEventoAsyncById(PalestranteId, false);
                if (palestrante == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    // return Ok();
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !!!");
            }

            return BadRequest();
        }
        // [HttpDelete]
        // public async Task<IActionResult> Delete(int EventoId)
        // {
        //     try
        //     {
        //         var evento = await _repo.GetEventoAsyncById(EventoId, false);
        //         if(evento == null) return NotFound();

        //         _repo.Delete(evento);

        //         if (await _repo.SaveChangesAsync())
        //         {
        //             return Ok();
        //         }
        //     }
        //     catch (System.Exception)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou !!!");
        //     }

        //     return BadRequest();
        // }
    }
}