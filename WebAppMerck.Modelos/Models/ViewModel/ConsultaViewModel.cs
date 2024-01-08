namespace WebAppMerck.Modelos.Models.ViewModel
{
    public class ConsultaViewModel
    {

        public int Id { get; set; }
        public string MotivoConsulta { get; set; } = null!;

        public string Clinica { get; set; } = null!;

        public DateTime FechaYhora { get; set; }
        public Uri Url { get; set; }
    }
}
