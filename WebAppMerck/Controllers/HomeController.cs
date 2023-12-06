using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMerck.Models;

namespace WebAppMerck.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

                var modelo = new FormularioData();
                return View(modelo);
        }


        [HttpPost]
        public IActionResult Index(FormularioData data)
        {
            if (ModelState.IsValid) 
            {
                return RedirectToAction("Indicador", data);
            }
            return View("Index", data);

        }

        [HttpGet]
        public IActionResult Indicador(FormularioData data)
        {
           TempData["EdadActual"] = data.EdadActual;
           TempData["EdadPrimeraMenstruacion"] = data.EdadPrimeraMenstruacion;
           TempData["NivelFertilidad"] = CalcularNivelFertilidad(data.EdadActual);

            return View(data);

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