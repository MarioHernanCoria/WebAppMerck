using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMerck.AccesoDatos.DataAccess;
using WebAppMerck.AccesoDatos.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebAppMerck.Modelos.Models.Entities;
using WebAppMerck.Modelos.Models.ViewModel;

namespace WebAppMerck.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public LoginController(AppDbContext context, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Ingresar(LoginDto model)
        {
            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(u => u.Email == model.Email && u.Clave == model.Clave);


            if (usuario != null)
            {
                return RedirectToAction("PantallaPrincipal", "Reporte");
            }

            ViewBag.ErrorLogin = "Las credenciales son incorrectas";
            return View("Login");
        }

        public IActionResult CerrarSesion()
        {
            // Cerrar la sesión del usuario
            HttpContext.SignOutAsync();

            // Redirigir a la vista de Login
            return RedirectToAction("Login", "Login");
        }
    }
}
