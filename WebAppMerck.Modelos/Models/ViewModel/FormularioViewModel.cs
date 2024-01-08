namespace WebAppMerck.Modelos.Models.ViewModel
{
    public class FormularioViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Celular { get; set; }
        public string? Clinicas { get; set; } = "";
        public string EmailClinica { get; set; }
        public string Consulta { get; set; }
    }
}
