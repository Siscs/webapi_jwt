using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lxwebapi.Data;
using lxwebapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lxwebapi.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController()
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.Include( x => x.Categoria).ToListAsync();
            return produtos;
         }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.Include(x => x.Categoria)
            .AsNoTracking()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
            
            return produto;
        }

        [HttpGet]
        [Route("categoria/{categoriaId:int}")]
        public async Task<ActionResult<List<Produto>>> GetByCategory([FromServices] DataContext context, int categoriaId)
        {
            var produtos = await context.Produtos.Include(p => p.Categoria)
            .AsNoTracking()
            .Where(x => x.CategoriaId == categoriaId)
            .ToListAsync();

            return produtos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post([FromServices] DataContext context, [FromBody] Produto model)
        {
            if(ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            } else {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("lote")]
        public async Task<ActionResult<List<Produto>>> Post([FromServices] DataContext context, [FromBody] List<Produto> produtos)
        {

            if(ModelState.IsValid)
            {
                context.Produtos.AddRange(produtos);
                await context.SaveChangesAsync();
                return produtos;

            }
            else
            {
                return BadRequest(ModelState);

            }

        }


    }
}