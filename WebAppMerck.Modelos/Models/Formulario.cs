using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Modelos.Models.ViewModel
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = "";

        public string Apellido { get; set; } = "";

        public string Email { get; set; } = "";

        public int Edad { get; set; }

        public string Celular { get; set; } = "";

        public string Clinicas { get; set; } = "";

        public string Consulta { get; set; } = "";

        [Required(ErrorMessage = "La edad actual es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad actual debe ser un número mayor que cero.")]
        public int EdadActual { get; set; }
        [Required(ErrorMessage = "La edad de la primera menstruación es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad de la primera menstruación debe ser un número mayor que cero.")]
        [ValidarEdadPrimeraMenstruacion(nameof(EdadActual), ErrorMessage = "La edad de la primera menstruación no puede ser mayor que la edad actual.")]
        [ValidarEdadDiferente(nameof(EdadActual), ErrorMessage = "La edad de la primera menstruación no puede ser igual a la edad actual.")]
        public int EdadPrimeraMenstruacion { get; set; }
        public string? NivelFertilidad { get; set; } = "";
    }


    public class ValidarEdadPrimeraMenstruacionAttribute : ValidationAttribute
    {
        private readonly string _edadActualPropertyName;

        public ValidarEdadPrimeraMenstruacionAttribute(string edadActualPropertyName)
        {
            _edadActualPropertyName = edadActualPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var edadPrimeraMenstruacion = (int)value;
            var edadActualProperty = validationContext.ObjectType.GetProperty(_edadActualPropertyName);

            if (edadActualProperty != null)
            {
                var edadActual = (int)edadActualProperty.GetValue(validationContext.ObjectInstance, null);

                if (edadPrimeraMenstruacion > edadActual)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
    public class ValidarEdadDiferenteAttribute : ValidationAttribute
    {
        private readonly string _otraEdadPropertyName;

        public ValidarEdadDiferenteAttribute(string otraEdadPropertyName)
        {
            _otraEdadPropertyName = otraEdadPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otraEdadProperty = validationContext.ObjectType.GetProperty(_otraEdadPropertyName);

            if (otraEdadProperty != null)
            {
                var otraEdad = (int)otraEdadProperty.GetValue(validationContext.ObjectInstance, null);

                if ((int)value == otraEdad)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
