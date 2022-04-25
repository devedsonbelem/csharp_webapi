using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoCrud.Models;
using projetoCrud.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projetoCrud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }
            return produtos;
        }
        

        [HttpDelete("{id}")]
        public async Task <ActionResult<Produto>> DeleteProduto(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }

        //CENFERE SE O ID EXISTE (TRUE OU FALSE)
        private bool ProdutoExiste(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Produto produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }
            _context.Entry(produtos).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

      





    }
}
