using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public class AsientoService
    {
        public List<Asiento> GenerarAsientosDisponibles()
        {
            BuilderService builderService = new();
            List<Asiento> asientosDisponibles = new List<Asiento>();

            CrearAsientosPorClase(asientosDisponibles);

            var asientosReservados = ObtenerAsientosReservados();

            foreach (var asiento in asientosDisponibles)
            {
                if (asientosReservados.Contains(asiento.CodigoReserva))
                {
                    builderService.CrearAsientoReservado(asiento);
                }
            }

            return asientosDisponibles;
        }

        public List<Asiento> CrearAsientosPorClase(List<Asiento> asientosDisponibles)
        {
            BuilderService builderService = new();

            for (int fila = 1; fila <= 3; fila++)
            {
                asientosDisponibles.Add(builderService.CrearAsiento("A" + fila, "Premium", true, false));
                asientosDisponibles.Add(builderService.CrearAsiento("B" + fila, "Premium", false, true));
                asientosDisponibles.Add(builderService.CrearAsiento("E" + fila, "Premium", false, true));
                asientosDisponibles.Add(builderService.CrearAsiento("F" + fila, "Premium", true, false));
            }

            for (int fila = 4; fila <= 8; fila++)
            {
                for (char columna = 'A'; columna <= 'F'; columna++)
                {
                    asientosDisponibles.Add(builderService.CrearAsiento($"{columna}{fila}", "Premium Economy", columna == 'A' || columna == 'F', columna == 'B' || columna == 'E'));
                }
            }

            for (int fila = 9; fila <= 27; fila++)
            {
                for (char columna = 'A'; columna <= 'F'; columna++)
                {
                    asientosDisponibles.Add(builderService.CrearAsiento($"{columna}{fila}", "Economy", columna == 'A' || columna == 'F', columna == 'B' || columna == 'E'));
                }
            }

            return asientosDisponibles;
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
                    var codigoReserva = datos[1];
                    asientosReservados.Add(codigoReserva);
                }
            }

            return asientosReservados;
        }
    }
}
