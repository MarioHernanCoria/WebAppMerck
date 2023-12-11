namespace WebAppMerck.Servicios
{
    public class CalcularFertilidad
    {
        public string CalcularNivelFertilidad(int edadActual)
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
