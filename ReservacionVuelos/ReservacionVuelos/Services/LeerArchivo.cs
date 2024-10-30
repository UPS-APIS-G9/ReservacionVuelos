namespace ReservacionVuelos.Services
{
    public class LeerArchivo
    {
        private static readonly Lazy<LeerArchivo> instance =
        new Lazy<LeerArchivo>(() => new LeerArchivo());

        private List<string> contenidoReservaciones;
        private List<string> contenidoSeleccionAsiento;
        private string rutaReservaciones;
        private string rutaSeleccionAsiento;

        private LeerArchivo() { }

        public static LeerArchivo Instance => instance.Value;

        public void InitializeFileReservations(string path)
        {
            if (contenidoReservaciones == null && File.Exists(path))
            {
                rutaReservaciones = path;
                contenidoReservaciones = new List<string>(File.ReadAllLines(rutaReservaciones));
            }
            else if (!File.Exists(path))
            {
                throw new FileNotFoundException($"El archivo {path} no existe.");
            }
        }

        public void InitializeFileSeatSelection(string path)
        {
            if (contenidoSeleccionAsiento == null && File.Exists(path))
            {
                rutaSeleccionAsiento = path;
                contenidoSeleccionAsiento = new List<string>(File.ReadAllLines(rutaSeleccionAsiento));
            }
            else if (!File.Exists(path))
            {
                throw new FileNotFoundException($"El archivo {path} no existe.");
            }
        }

        public List<string> GetcontenidoReservaciones()
        {
            if (contenidoReservaciones == null)
            {
                throw new InvalidOperationException("El archivo reservations.txt no ha sido inicializado. Llama al método InitializeFileReservations primero.");
            }
            return contenidoReservaciones;
        }

        public List<string> GetcontenidoSeleccionAsiento()
        {
            if (contenidoSeleccionAsiento == null)
            {
                throw new InvalidOperationException("El archivo Seat-selection.txt no ha sido inicializado. Llama al método InitializeFileSeatSelection primero.");
            }
            return contenidoSeleccionAsiento;
        }
    }
}
