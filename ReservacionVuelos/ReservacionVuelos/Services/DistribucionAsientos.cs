using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public class DistribucionAsientos
    {
        public static readonly Dictionary<string, (int filaInicio, int filaFin, int maxAsientos, List<string> columnas)> Clases = new()
        {
            {
                "Premium", (1, 3, 12, new List<string> { "A", "B", "E", "F" })
            },
            {
                "Premium Economy", (4, 8, 30, new List<string> { "A", "B", "C", "D", "E", "F" })
            },
            {
                "Economy", (9, 27, 114, new List<string> { "A", "B", "C", "D", "E", "F" })
            }
        };

        public static bool EsAsientoValido(string clase, int fila, string columna, List<Asiento> asientosSeleccionados)
        {
            if (!Clases.ContainsKey(clase)) return false;

            var (filaInicio, filaFin, maxAsientos, columnasValidas) = Clases[clase];

            // Validar rango de filas, columna y límite de asientos
            if (fila >= filaInicio && fila <= filaFin && columnasValidas.Contains(columna))
            {
                int asientosEnClase = asientosSeleccionados.Count(a => a.Categoria == clase);
                return asientosEnClase < maxAsientos;
            }

            return false;
        }
    }
}
