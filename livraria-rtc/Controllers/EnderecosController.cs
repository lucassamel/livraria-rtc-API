using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using livraria_rtc.Context;
using livraria_rtc.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace livraria_rtc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly LivrariaContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EnderecosController(LivrariaContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return await _context.Endereco.ToListAsync();
        }

        // GET: api/Enderecos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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

        // POST: api/Enderecos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            var account = await _userManager.GetUserAsync(this.User);
            var perfilLogado = await _context.Usuario
                .FirstAsync(p => p.Email == account.Email);

            endereco.UsuarioId = perfilLogado.UsuarioId;

            _context.Endereco.Add(endereco);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.EnderecoId }, endereco);
        }

        // DELETE: api/Enderecos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> DeleteEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.EnderecoId == id);
        }
    }
}
