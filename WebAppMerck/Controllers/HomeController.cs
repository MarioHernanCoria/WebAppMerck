using Microsoft.AspNetCore.Mvc;
using WebAppMerck.Servicios;
using Microsoft.Extensions.Configuration;
using WebAppMerck.Models;
using Microsoft.Extensions.DependencyInjection;
using WebAppMerck.Servicios.Interfaces;
using System;

namespace WebAppMerck.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalcularFertilidad _calcularFertilidad;
        private readonly IHttpClientFactory _httpClient;
        private readonly ClinicasServicio _clinicasServicio;
        private readonly IConfiguration _configuration;

        public HomeController(IHttpClientFactory httpClient, ClinicasServicio clinicasServicio, IConfiguration configuration, CalcularFertilidad calcularFertilidad)
        {
            _calcularFertilidad = calcularFertilidad;
            _httpClient = httpClient;
            _clinicasServicio = clinicasServicio;
            _configuration = configuration;

        }
        public IActionResult Index()
        {
            var bingMapsApiKey = _configuration["BingMapsCredentials:ApiKey"];
            ViewData["BingMapsApiKey"] = bingMapsApiKey;

            var modelo = new Formulario();
            return View(modelo);
        }

        public IActionResult Consulta()
        {
            return View();
        }

        public IActionResult AgradecimientoConsulta()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Formulario data)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Indicador", data);
            }
            return View("Index", data);

        }

        [HttpGet]
        public IActionResult Indicador(Formulario data)
        {
            TempData["EdadActual"] = data.EdadActual;
            TempData["EdadPrimeraMenstruacion"] = data.EdadPrimeraMenstruacion;
            TempData["NivelFertilidad"] = _calcularFertilidad.CalcularNivelFertilidad(data.EdadActual);

            ViewData["EdadActual"] = data.EdadActual;
            ViewData["NivelFertilidad"] = TempData["NivelFertilidad"];

            return View(data);

        }

        [HttpGet]
        public IActionResult GetBingMapsApiKey()
        {
            var apiKey = _configuration["BingMapsCredentials:ApiKey"];
            return Json(new { apiKey });
        }


        public async Task<IActionResult> ObtenerClinicas()
        {
            var archivoCsv = "https://raw.githubusercontent.com/MarioHernanCoria/clinicas/main/clinicasFertilidad.csv";
            var clinicas = await _clinicasServicio.ObtenerClinicasCsv(archivoCsv);
            var clinicasDto = _clinicasServicio.ConvertirClinicas(clinicas);
            return Json(clinicasDto);
        }

        
    }
}