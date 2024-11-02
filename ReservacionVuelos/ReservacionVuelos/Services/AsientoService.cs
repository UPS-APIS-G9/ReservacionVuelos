using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public class AsientoService
    {
        
        private readonly BuilderService BuilderService;

        public AsientoService(BuilderService builderService)
        {
            BuilderService = builderService;
        }

        public List<Asiento> GenerarAsientosDisponibles()
        {
            List<Asiento> asientosDisponibles = new List<Asiento>();

            CrearAsientosPorClase(asientosDisponibles);

            var asientosReservados = ObtenerAsientosReservados();

            foreach (var asiento in asientosDisponibles)
            {
                if (asientosReservados.Contains(asiento.CodigoAsiento))
                {
                    this.BuilderService.CrearAsientoReservado(asiento);
                }
            }

            return asientosDisponibles;
        }

        private void CrearAsientosPorClase(List<Asiento> asientosDisponibles)
        {

            for (int fila = 1; fila <= 3; fila++)
            {
                asientosDisponibles.Add(BuilderService.CrearAsiento("A" + fila, "P", true, false));
                asientosDisponibles.Add(BuilderService.CrearAsiento("B" + fila, "P", false, true));
                asientosDisponibles.Add(BuilderService.CrearAsiento("E" + fila, "P", false, true));
                asientosDisponibles.Add(BuilderService.CrearAsiento("F" + fila, "P", true, false));
            }

            for (int fila = 4; fila <= 27; fila++)
            {
                for (char columna = 'A'; columna <= 'F'; columna++)
                {
                    asientosDisponibles.Add(BuilderService.CrearAsiento($"{columna}{fila}", "Y", columna == 'A' || columna == 'F', columna == 'B' || columna == 'E'));
                }
            }
        }

        private HashSet<string> ObtenerAsientosReservados()
        {
            var asientosReservados = new HashSet<string>();
            List<string> contenidoSeleccionAsientos = LeerArchivo.Instance.GetcontenidoSeleccionAsiento();

            foreach (var linea in contenidoSeleccionAsientos)
            {
                var datos = linea.Split('|');
                if (datos.Length >= 2)
                {
                    var codigoAsiento = datos[1];
                    asientosReservados.Add(codigoAsiento);
                }
            }

            return asientosReservados;
        }

        public readonly Dictionary<string, (int filaInicio, int filaFin, int maxAsientos, List<string> columnas)> Clases = new()
        {
            {
                "P", (1, 3, 12, new List<string> { "A", "B", "E", "F" })
            },
            {
                "Y", (4, 27, 144, new List<string> { "A", "B", "C", "D", "E", "F" })
            }
        };

        public bool EsAsientoValido(string clase, int fila, string columna, List<Asiento> asientosSeleccionados)
        {
            if (!Clases.ContainsKey(clase)) return false;

            var (filaInicio, filaFin, maxAsientos, columnasValidas) = Clases[clase];

            if (fila >= filaInicio && fila <= filaFin && columnasValidas.Contains(columna))
            {
                int asientosEnClase = asientosSeleccionados.Count(a => a.Categoria == clase);
                return asientosEnClase <= maxAsientos;
            }

            return false;
        }

        public string ObtenerClasePorFila(int fila)
        {
            if (fila >= 1 && fila <= 3) return "P";
            if (fila >= 4 && fila <= 27) return "Y";
            return "Desconocida";
        }
    }

}
