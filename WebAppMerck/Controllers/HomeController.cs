using Microsoft.AspNetCore.Mvc;
using WebAppMerck.Models;
using WebAppMerck.Servicios;

namespace WebAppMerck.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalcularFertilidad _calcularFertilidad;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClinicasServicio _clinicasServicio;
        private readonly IConfiguration _configuration;

        public HomeController(IHttpClientFactory httpClientFactory, ClinicasServicio clinicasServicio, IConfiguration configuration, CalcularFertilidad calcularFertilidad)
        {
            _calcularFertilidad = calcularFertilidad;
            _httpClientFactory = httpClientFactory;
            _clinicasServicio = clinicasServicio;
            _configuration = configuration;

        }
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
           TempData["NivelFertilidad"] = _calcularFertilidad.CalcularNivelFertilidad(data.EdadActual);

            return View(data);

        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClinicasFertilidad()
        {
            var archivoCsv = "https://raw.githubusercontent.com/MarioHernanCoria/ClinicasCSV/main/Clinicas%20de%20Fertilidad.csv";
            var clinicas = await _clinicasServicio.ObtenerClinicasCsv(archivoCsv);
            var clinicasDto = _clinicasServicio.ConvertirClinicas(clinicas);
            return Json(clinicasDto);
        }
    }
}