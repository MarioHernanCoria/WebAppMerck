using Microsoft.AspNetCore.Mvc;
using WebAppMerck.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebAppMerck.Servicios.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMerck.DataAccess;
using Newtonsoft.Json;
using WebAppMerck.Models.DTOs;
using System.Linq;
using WebAppMerck.Models.Key;
using WebAppMerck.Models.ViewModel;
using WebAppMerck.Models.Entities;
using WebAppMerck.Models;
using static System.Net.WebRequestMethods;

namespace WebAppMerck.Controllers
{
    public class HomeController : Controller
    {
        private readonly BdAppMerckContext _appMerckContext;
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;
        private readonly IEmailSender _emailSender;
        private readonly CalcularFertilidad _calcularFertilidad;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClinicasServicio _clinicasServicio;
        private readonly IConfiguration _configuration;

        public HomeController(BdAppMerckContext appMerckContext, IOptions<GoogleAnalyticsOptions> googleAnalyticsOptions, IEmailSender emailSender, IHttpClientFactory httpClientFactory, ClinicasServicio clinicasServicio, IConfiguration configuration, CalcularFertilidad calcularFertilidad)
        {
            _appMerckContext = appMerckContext;
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

        public IActionResult TextoInformativoGrafico()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            var modelo = new FormularioViewModel();
            return View(modelo);
        }

        public IActionResult ConsultaFinal()
        {
            var viewModel = new UbicacionViewModel
            {
                // Obtener la lista de provincias utilizando GetSelectListItems
                Provincias = GetSelectListItems(
                    items: _appMerckContext.Provincia.ToList(),
                    valueSelector: p => p.Id.ToString(),
                    textSelector: p => p.Provincias
                ),

                // Obtener la lista de clínicas utilizando GetSelectListItems
                ClinicasItems = GetSelectListItems(
                    items: _appMerckContext.Clinicas.ToList(),
                    valueSelector: c => c.Id.ToString(),
                    textSelector: c => c.Nombre
                ),
            };

            return View("ConsultaFinal", viewModel);
        }
        private List<SelectListItem> GetSelectListItems<T>(IEnumerable<T> items, Func<T, string> valueSelector, Func<T, string> textSelector)
        {
            return items.Select(item => new SelectListItem
            {
                Value = valueSelector(item),
                Text = textSelector(item)
            }).ToList();
        }

        //[HttpPost]
        //public JsonResult ObtenerLocalidades(int idProvincia)
        //{
        //    var localidades = _appMerckContext.Localidades
        //        .Where(l => l.IdProvincia == idProvincia)
        //        .ToList();

        //    return Json(localidades);
        //}

        public IActionResult ObtenerClinicas(UbicacionViewModel viewModel)
        {
            if (viewModel.Provincia == null)
            {
                return Json(new List<ClinicasDto>());
            }

            var clinicas = _clinicasServicio.ObtenerClinicasCsv();
            var clinicasDto = _clinicasServicio.ConvertirClinicas(clinicas);

            var clinicasFiltradas = clinicas.Where(c => c.Provincia == "ProvinciaElegida").ToList();

            return Json(clinicasDto);
        }



        [HttpGet]
        public IActionResult GetBingMapsApiKey()
        {
            var apiKey = _configuration["BingMapsCredentials:ApiKey"];
            return Json(new { apiKey });
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


//public IActionResult ConsultaFinal()
//{
//    var viewModel = new UbicacionViewModel
//    {
//        Provincias = _appMerckContext.Provincia
//            .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Provincias })
//            .ToList(),

//        ClinicasItems = _appMerckContext.Clinicas
//            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre })
//            .ToList()
//    };

//    return View("ConsultaFinal", viewModel);
//}