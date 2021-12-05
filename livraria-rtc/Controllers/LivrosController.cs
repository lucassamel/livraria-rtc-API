using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using livraria_rtc.Context;
using livraria_rtc.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace livraria_rtc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrariaContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public LivrosController(LivrariaContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        [HttpGet("userLivros/{id}")]
        public async Task<ActionResult<IEnumerable<Livro>>> GetUserLivros(int id )
        {
            //var account = await _userManager.GetUserAsync(this.User);
            //var perfilLogado = await _context.Usuario
            //    .FirstAsync(p => p.Email == account.Email);

            //var query = new SqlCommand("SELECT Livro FROM Livros WHERE UsuarioId = @UsuarioId");
            var livros = _context.Livros.Where(p => p.UsuarioId == id).ToListAsync();
           
            if (livros == null)
            {
                return NotFound();
            }

            return await livros;
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // PUT: api/Livros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // POST: api/Livros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            //var account = await _userManager.GetUserAsync(this.User);
            //var perfilLogado = await _context.Usuario
            //    .FirstAsync(p => p.Email == account.Email);

            //livro.UsuarioId = perfilLogado.UsuarioId;

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { id = livro.LivroId }, livro);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livro>> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.LivroId == id);
        }
    }
}
