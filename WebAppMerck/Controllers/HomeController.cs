using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMerck.Models;

namespace WebAppMerck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var modelo = new FormularioData();
            return View(modelo);
        }
        
        public IActionResult Indicador(FormularioData data)
        {
            TempData["EdadActual"] = data.EdadActual;
            TempData["EdadPrimeraMenstruacion"] = data.EdadPrimeraMenstruacion;
            TempData["NivelFertilidad"] = CalcularNivelFertilidad(data.EdadActual);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string CalcularNivelFertilidad(int edadActual)
        {
            int umbralBaja = 35;
            int umbralMedio = 28;

            if (edadActual > umbralBaja)
            {
                return "Baja";
            }
            else if (edadActual <= umbralBaja && edadActual > umbralMedio)
            {
                return "Media";
            }
            else
            {
                return "Alta";
            }
        }
    }
}