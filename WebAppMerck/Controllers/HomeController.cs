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

        public IActionResult AgradecimientoConsulta()
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

            ModelState.AddModelError("EdadActual", "Por favor, seleccione una edad válida.");
            ModelState.AddModelError("EdadPrimeraMenstruacion", "Por favor, seleccione una edad válida.");
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
                Provincias = GetSelectListItems(
                    items: _appMerckContext.Provincia.ToList(),
                    valueSelector: p => p.Id.ToString(),
                    textSelector: p => p.Provincias
                ),

                ClinicasItems = GetSelectListItems(
                    items: _appMerckContext.Clinicas.ToList(),
                    valueSelector: c => c.Id.ToString(),
                    textSelector: c => c.Nombre
                ),

                Localidades = GetSelectListItems(
                    items: _appMerckContext.Localidades.ToList(),
                    valueSelector: c => c.Id.ToString(),
                    textSelector: c => c.Localidades
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


        [HttpGet]
        public IActionResult ObtenerLocalidades(string provincia)
        {
            if (string.IsNullOrEmpty(provincia))
            {
                return Json(new List<SelectListItem>());
            }
            int idProvincia = Convert.ToInt32(provincia); 

            // Aquí deberías obtener las localidades filtradas por la provincia seleccionada
            var localidadesFiltradas = _appMerckContext.Localidades
                .Where(l => l.IdProvincia == idProvincia)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Localidades
                })
                .ToList();

            return Json(localidadesFiltradas);
        }

        [HttpGet]
        public IActionResult ObtenerClinicas(string provincia)
        {
            if (string.IsNullOrEmpty(provincia))
            {
                return Json(new List<SelectListItem>());
            }

            // Crear un diccionario de mapeo de códigos de provincia a nombres de provincia
            var provincias = new Dictionary<string, string>
                {
                    {"1", "Buenos Aires" },
                    {"2", "Buenos Aires-GBA" },
                    {"3", "Capital Federal" },
                    {"4", "Catamarca"},
                    {"5", "Chaco"},
                    {"6", "Chubut"},
                    {"7", "Córdoba"},
                    {"8", "Corrientes"},
                    {"9", "Entre Ríos"},
                    {"10", "Formosa"},
                    {"11", "Jujuy"},
                    {"12", "La Pampa"},
                    {"13", "La Rioja"},
                    {"14", "Mendoza"},
                    {"15", "Misiones"},
                    {"16", "Neuquén"},
                    {"17", "Río Negro"},
                    {"18", "Salta"},
                    {"19", "San Juan"},
                    {"20", "San Luis"},
                    {"21", "Santa Cruz"},
                    {"22", "Santa Fe"},
                    {"23", "Santiago del Estero"},
                    {"24", "Tierra del Fuego"},
                    {"25", "Tucumán"},
                };
            
            // Obtener el nombre de la provincia usando el código
            if (provincias.TryGetValue(provincia, out var nombreProvincia))
            {
                var clinicasFiltradas = _appMerckContext.Clinicas
                    .Where(c => c.Provincia == nombreProvincia)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nombre
                    })
                    .ToList();

                return Json(clinicasFiltradas);
            }
            else
            {
                return Json(new List<SelectListItem>());
            }
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
        //public IActionResult ObtenerClinicas(UbicacionViewModel viewModel)
        //{
        //    if (viewModel.Provincia == null)
        //    {
        //        return Json(new List<ClinicasDto>());
        //    }

        //    var clinicas = _clinicasServicio.ObtenerClinicasCsv();
        //    var clinicasDto = _clinicasServicio.ConvertirClinicas(clinicas);

        //    var clinicasFiltradas = clinicas.Where(c => c.Provincia == "ProvinciaElegida").ToList();
        //    return Json(clinicasFiltradas);
        //}
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

//[HttpPost]
//public JsonResult ObtenerLocalidades(string idProvincia)
//{
//    var localidades = _appMerckContext.Localidades
//        .ToList();

//    return Json(localidades);
//}


//[HttpGet]
//public IActionResult ObtenerClinicas(string provincia)
//{
//    if (string.IsNullOrEmpty(provincia))
//    {
//        return Json(new List<SelectListItem>());
//    }

//    var clinicasFiltradas = _appMerckContext.Clinicas
//        .Where(c => c.Provincia == provincia)
//        .Select(c => new SelectListItem
//        {
//            Value = c.Id.ToString(),
//            Text = c.Nombre
//        })
//        .ToList();

//    return Json(clinicasFiltradas);
//}

//[HttpGet]
//public IActionResult ObtenerClinicas(string provincia)
//{
//    if (string.IsNullOrEmpty(provincia))
//    {
//        return Json(new List<SelectListItem>());
//    }

//    // Crear un diccionario de mapeo de códigos de provincia a nombres de provincia
//    var provincias = new Dictionary<string, string>
//        {
//            { "1", "Buenos Aires" },
//            { "2", "Buenos Aires-GBA" },
//            {"3", "Capital Federal" },
//            {"4", "Catamarca"},
//            {"5", "Chaco"},
//            {"6", "Chubut"},
//            {"7", "Córdoba"},
//            {"8", "Corrientes"},
//            {"9", "Entre Ríos"},
//            {"10", "Formosa"},
//            {"11", "Jujuy"},
//            {"12", "La Pampa"},
//            {"13", "La Rioja"},
//            {"14", "Mendoza"},
//            {"15", "Misiones"},
//            {"16", "Neuquén"},
//            {"17", "Río Negro"},
//            {"18", "Salta"},
//            {"19", "San Juan"},
//            {"20", "San Luis"},
//            {"21", "Santa Cruz"},
//            {"22", "Santa Fe"},
//            {"23", "Santiago del Estero"},
//            {"24", "Tierra del Fuego"},
//            {"25", "Tucumán"},
//        };

//    // Obtener el nombre de la provincia usando el código
//    if (provincias.TryGetValue(provincia, out var nombreProvincia))
//    {
//        var clinicasFiltradas = _appMerckContext.Clinicas
//            .Where(c => c.Provincia == nombreProvincia)
//            .Select(c => new SelectListItem
//            {
//                Value = c.Id.ToString(),
//                Text = c.Nombre
//            })
//            .ToList();

//        return Json(clinicasFiltradas);
//    }
//    else
//    {
//        return Json(new List<SelectListItem>());
//    }
//}