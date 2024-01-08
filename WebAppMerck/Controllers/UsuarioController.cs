using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppMerck.Modelos.Models.Entities;
using WebAppMerck.Modelos.Models.ViewModel;

namespace WebAppMerck.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsuarioController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro()
        {
            if(!await _roleManager.RoleExistsAsync("Administrador"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrador"));
            }
            if (!await _roleManager.RoleExistsAsync("Usuario"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Usuario"));
            }

            RegistroViewModel registroViewModel = new RegistroViewModel();

            return View(registroViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel rgViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario { UserName = rgViewModel.Email, Email = rgViewModel.Email, Clave = rgViewModel.Clave };
                var resultado = await _userManager.CreateAsync(usuario, rgViewModel.Clave);

                if (resultado.Succeeded)
                {
                    // Esta linea es para la asignacion del usuario que se registra al rol
                    await _userManager.AddToRoleAsync(usuario, "Usuario");

                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    return RedirectToAction("Login", "Login");
                }
                ValidarErrores(resultado);
            }
            return View(rgViewModel);
        }


        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }



    }
}
