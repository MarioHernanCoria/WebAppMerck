using Microsoft.AspNetCore.Mvc;
using WebAppMerck.Servicios;
using Microsoft.Extensions.Configuration;
using WebAppMerck.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebAppMerck.Servicios.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace WebAppMerck.Controllers
{
    public class HomeController : Controller
    {
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;
        private readonly IEmailSender _emailSender;
        private readonly CalcularFertilidad _calcularFertilidad;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClinicasServicio _clinicasServicio;
        private readonly IConfiguration _configuration;

        public HomeController(IOptions<GoogleAnalyticsOptions> googleAnalyticsOptions, IEmailSender emailSender, IHttpClientFactory httpClientFactory, ClinicasServicio clinicasServicio, IConfiguration configuration, CalcularFertilidad calcularFertilidad)
        {
            _googleAnalyticsOptions = googleAnalyticsOptions.Value;
            _emailSender = emailSender;
            _calcularFertilidad = calcularFertilidad;
            _httpClientFactory = httpClientFactory;
            _clinicasServicio = clinicasServicio;
            _configuration = configuration;

        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewData["TrackingId"] = _googleAnalyticsOptions.TrackingId;

            var bingMapsApiKey = _configuration["BingMapsCredentials:ApiKey"];
            ViewData["BingMapsApiKey"] = bingMapsApiKey;

            var modelo = new Formulario();
            return View(modelo);
        }


        [HttpGet]
        public IActionResult GetBingMapsApiKey()
        {
            var apiKey = _configuration["BingMapsCredentials:ApiKey"];
            return Json(new { apiKey });
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

        [HttpPost]
        public IActionResult Index(Formulario data)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Indicador", data);
            }
            return View("Index", data);

        }

        public IActionResult Consulta()
        {
            var modelo = new FormularioViewModel();
            return View(modelo);
        }

        public IActionResult AgradecimientoConsulta()
        {

            return View();
        }



        public async Task<IActionResult> ObtenerClinicas()
        {
            var archivoCsv = "https://raw.githubusercontent.com/MarioHernanCoria/clinicas/main/clinicasFertilidad.csv";
            var clinicas = await _clinicasServicio.ObtenerClinicasCsv(archivoCsv);
            var clinicasDto = _clinicasServicio.ConvertirClinicas(clinicas);
            return Json(clinicasDto);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarConsulta(FormularioViewModel formularioViewModel)
        {
            if (ModelState.IsValid)
            {
                var apiKey = _configuration["SendGridSettings:ApiKeySendGrid"];
                var senderEmail = _configuration["SendGridSettings:SenderEmail"];
                var subject = "Nueva consulta";

                // Utiliza el correo de la clínica seleccionada en lugar del destinatario estático
                var recipientEmail = formularioViewModel.EmailClinica;

                var message = $"Nueva consulta de {formularioViewModel.Nombre} {formularioViewModel.Apellido}. Mensaje: {formularioViewModel.Consulta}";

                await _emailSender.EnviarEmailAsync(senderEmail, recipientEmail, subject, message);

                return RedirectToAction("AgradecimientoConsulta");
            }

            return View("Consulta", formularioViewModel);
        }
    }
}