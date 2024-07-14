using GestoresAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly GestoresContext _gestoresContext;

        public GestoresController(GestoresContext gestores)
        {
            this._gestoresContext = gestores;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<GestoresBd> lista = await _gestoresContext.GestoresBds.OrderByDescending(c => c.Id).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] GestoresBd request)
        {
            await _gestoresContext.GestoresBds.AddAsync(request);
            await _gestoresContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] GestoresBd request)
        {
            _gestoresContext.GestoresBds.Update(request);
            await _gestoresContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

        [HttpDelete("{id}")]
        //[Route("Eliminar/{id:int)}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            GestoresBd gestores = _gestoresContext.GestoresBds.Find(id);

            _gestoresContext.GestoresBds.Remove(gestores);
            await _gestoresContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }
    }
}
