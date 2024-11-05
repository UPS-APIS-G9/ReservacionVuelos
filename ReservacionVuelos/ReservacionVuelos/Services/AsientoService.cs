using ReservacionVuelos.Builders;
using ReservacionVuelos.DTOs;
using ReservacionVuelos.Entities;

namespace ReservacionVuelos.Services
{
    public class AsientoService : IAsientoService
    {

        private readonly IAsientoBuilder _asientoBuilder;

        public AsientoService(IAsientoBuilder asientoBuilder)
        {
            _asientoBuilder = asientoBuilder;
        }

        public List<Asiento> GenerarAsientosDisponibles(List<Reservacion> reservaciones)
        {
            List<Asiento> asientosDisponibles = new List<Asiento>();

            CrearAsientosPorClase(asientosDisponibles);

            return asientosDisponibles;
        }

        private void CrearAsientosPorClase(List<Asiento> asientosDisponibles)
        {

            for (int fila = 1; fila <= 3; fila++)
            {
                asientosDisponibles.Add(this.CrearAsiento("A" + fila, "P", true, false));
                asientosDisponibles.Add(this.CrearAsiento("B" + fila, "P", false, true));
                asientosDisponibles.Add(this.CrearAsiento("E" + fila, "P", false, true));
                asientosDisponibles.Add(this.CrearAsiento("F" + fila, "P", true, false));
            }

            for (int fila = 4; fila <= 27; fila++)
            {
                for (char columna = 'A'; columna <= 'F'; columna++)
                {
                    asientosDisponibles.Add(this.CrearAsiento($"{columna}{fila}", "Y", columna == 'A' || columna == 'F', columna == 'B' || columna == 'E'));
                }
            }
        }

        private readonly Dictionary<string, (int filaInicio, int filaFin, int maxAsientos, List<string> columnas)> Clases = new()
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

        public bool PuedeSeleccionarAsiento(DateTime fechaHoraVuelo, bool esNacional)
        {
            TimeSpan tiempoRestante = fechaHoraVuelo - DateTime.Now;

            if (esNacional)
            {
                return tiempoRestante.TotalHours >= 6;
            }
            else
            {
                return tiempoRestante.TotalHours >= 12;
            }
        }
        public bool EsAsientoPermitidoParaClasePasajero(string clasePasajero, string claseAsiento)
        {
            if (clasePasajero == "P")
            {
                return claseAsiento == "P" || claseAsiento == "Y";
            }
            else
            {
                return claseAsiento != "P";
            }
        }

        public List<Reservacion> GenerarAsientosOcupados(List<Reservacion> reservaciones)
        {
            List<Reservacion> reservasConAsientoOcupado = new();

            reservasConAsientoOcupado = reservaciones.FindAll(reserva => reserva.AsientoSeleccionado.Reservado);

            return reservasConAsientoOcupado;
        }

        private Asiento CrearAsiento(string codigoAsiento, string categoria, bool esVentana, bool esPasillo) =>
            _asientoBuilder
                .SetCodigoAsiento(codigoAsiento)
                .SetCategoria(categoria)
                .SetEsVentana(esVentana)
                .SetEsPasillo(esPasillo)
                .Build();

        public Asiento CrearAsiento(ReservacionInfo info) =>
            _asientoBuilder.SetCodigoReserva(info.CodigoReserva)
                .SetCategoria(info.CategoriaAsiento)
                .Build();

        public Asiento ActualizarAsiento(Reservacion info, string codigoAsiento, bool reservado) =>
            _asientoBuilder
                .SetCodigoReserva(info.CodigoReserva)
                .SetCodigoAsiento(codigoAsiento)
                .SetCategoria(info.AsientoSeleccionado.Categoria)
                .SetReservado(reservado)
                .Build();

        public Asiento ActualizarAsientoReservado(string codigoReserva, Asiento asiento) =>
            _asientoBuilder
                .SetCodigoAsiento(asiento.CodigoAsiento)
                .SetCodigoReserva(codigoReserva)
                .SetCategoria(asiento.Categoria)
                .SetEsVentana(asiento.EsVentana)
                .SetEsPasillo(asiento.EsPasillo)
                .SetReservado(true)
                .Build();

    }



}
