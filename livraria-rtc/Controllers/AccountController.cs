using System.Linq;
using System.Threading.Tasks;
using livraria_rtc.Context;
using livraria_rtc.Identity;
using livraria_rtc.Model;
using livraria_rtc.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livraria_rtc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly LivrariaContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            LivrariaContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest model)
        {
            // Copia os dados do RegisterViewModel para o IdentityUser
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            // Armazena os dados do usuário na tabela AspNetUsers
            var result = await _userManager.CreateAsync(user, model.Password);

            // Copia os dados do RegisterModel para a tabela Usuario
            var usuario = new Usuario
            {
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Email = model.Email                
            };


            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();          

           
            // Se o usuário foi criado com sucesso, faz o login do usuário
            // usando o serviço SignInManager e redireciona para o Método Action Index
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);


                return Ok(usuario);
            }
            // Se houver erros então inclui no ModelState
            // que será exibido pela tag helper summary na validação
            return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
        }

        //Método que faz o Logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Login Inválido");
            }

            var usuario = _context.Usuario
                .Single(u => u.Email == model.Email);

            return Ok(usuario);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<Usuario>> GetUser()
        {
            var account = await _userManager.GetUserAsync(this.User);
            var perfilLogado = await _context.Usuario
                .FirstAsync(p => p.Email == account.Email);

            return perfilLogado;
        }

    }
}
