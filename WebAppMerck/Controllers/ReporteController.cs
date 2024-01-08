using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Data;
using WebAppMerck.AccesoDatos.DataAccess;
using WebAppMerck.Modelos.Models.Entities;
using WebAppMerck.Modelos.Models.ViewModel;


namespace WebAppMerck.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ReporteController : Controller
    {
        private readonly AppDbContext _context;

        public ReporteController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PantallaPrincipal()
        {
            return View();
        }


        public IActionResult ImprimirPdf(DateTime? fechaInicio, DateTime? fechaFin)
        {
            IQueryable<Consulta> consultasQuery = _context.Consultas;

            if (fechaInicio != null)
            {
                // Considerar solo la parte de la fecha
                fechaInicio = fechaInicio?.Date;
                consultasQuery = consultasQuery.Where(c => c.FechaYhora.Date >= fechaInicio);
            }

            if (fechaFin != null)
            {
                // Considerar solo la parte de la fecha
                fechaFin = fechaFin?.Date;
                consultasQuery = consultasQuery.Where(c => c.FechaYhora.Date <= fechaFin);
            }

            List<ConsultaViewModel> consultas = consultasQuery
                .Select(v => new ConsultaViewModel()
                {
                    MotivoConsulta = v.MotivoConsulta,
                    Clinica = v.Clinica,
                    FechaYhora = v.FechaYhora,
                    Url = v.Url,
                })
                .ToList();

            return new ViewAsPdf("/Views/Reporte/ImprimirPdf.cshtml", consultas)
            {
                FileName = "Consultas.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        [HttpGet]
        public async Task<FileResult> ExportarPersonasAExcel(DateTime? fechaInicio, DateTime? fechaFin)
        {
            IQueryable<Consulta> consultasQuery = _context.Consultas;

            if (fechaInicio != null)
            {
                // Considerar solo la parte de la fecha
                fechaInicio = fechaInicio?.Date;
                consultasQuery = consultasQuery.Where(c => c.FechaYhora.Date >= fechaInicio);
            }

            if (fechaFin != null)
            {
                // Considerar solo la parte de la fecha
                fechaFin = fechaFin?.Date;
                consultasQuery = consultasQuery.Where(c => c.FechaYhora.Date <= fechaFin);
            }

            var consultas = await consultasQuery.ToListAsync();
            var nombreArchivo = $"Reporte.xlsx";
            return GenerarExcel(nombreArchivo, consultas);
        }

        private FileResult GenerarExcel(string nombreArchivo, IEnumerable<Consulta> consultas)
        {
            DataTable dataTable = new DataTable("Reporte");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MotivoConsulta"),
                new DataColumn("Clinica"),
                new DataColumn("FechaYhora"),
                new DataColumn("Url")
            });

            foreach (var consulta in consultas)
            {
                dataTable.Rows.Add(
                    consulta.MotivoConsulta,
                    consulta.Clinica,
                    consulta.FechaYhora,
                    consulta.Url
                    );
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        nombreArchivo);
                }
            }
        }
    }
}
