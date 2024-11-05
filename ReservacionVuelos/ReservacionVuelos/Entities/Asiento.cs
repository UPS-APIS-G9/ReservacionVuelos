namespace ReservacionVuelos.Entities
{
    public class Asiento
    {
        public string CodigoReserva { get; set; }
        public string CodigoAsiento { get; set; }
        public string Categoria { get; set; }
        public bool EsVentana { get; set; } = false;
        public bool EsPasillo { get; set; } = false;
        public bool Reservado { get; set; } = false;

        public Asiento() { }
        
    }


}
