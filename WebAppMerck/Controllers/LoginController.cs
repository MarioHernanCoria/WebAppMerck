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

    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(AppDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
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

        public async Task<IActionResult> Ingresar(AccesoViewModel accViewModel)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(accViewModel.Email, accViewModel.Clave, accViewModel.Recordarme, lockoutOnFailure: false);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("PantallaPrincipal", "Reporte");
                } 
            }
            return View("Login", accViewModel);
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
