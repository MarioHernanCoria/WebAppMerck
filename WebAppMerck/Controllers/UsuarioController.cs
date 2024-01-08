using Microsoft.AspNetCore.Mvc;

namespace WebAppMerck.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
