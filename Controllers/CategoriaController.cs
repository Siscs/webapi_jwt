
using System.Collections.Generic;
using System.Threading.Tasks;
using lxwebapi.Data;
using lxwebapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lxwebapi.Controllers
{
    [ApiController]
    [Route("v1/categorias")]
    public class CategoriaController : ControllerBase
    {

        public CategoriaController()
        {
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            return await context.Categorias.ToListAsync();
            
        }

        [HttpGet]
        [Route("id/{id}")]
        [Authorize(Roles="Supervisor")]
        public async Task<ActionResult<Categoria>> GetById([FromServices] DataContext context, int id)
        {
            var categoria = await context.Categorias.FindAsync(id);

            if(categoria == null) return NotFound(new { message="categoria não encontrada"});

            return categoria;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Categoria>> Post([FromServices] DataContext context, [FromBody] Categoria model)
        {
            if(ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            } else {
                return BadRequest(ModelState);
            }
        }

        [Route("lote")]
        [Authorize]
        public async Task<ActionResult<List<Categoria>>> PostLote([FromServices] DataContext context, [FromBody] List<Categoria> categorias)
        {

            if(ModelState.IsValid)
            {
                context.Categorias.AddRange(categorias);
                await context.SaveChangesAsync();
                return categorias;

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}