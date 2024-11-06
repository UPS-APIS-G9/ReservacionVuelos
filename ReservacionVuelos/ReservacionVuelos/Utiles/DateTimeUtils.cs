namespace ReservacionVuelos.Utiles
{
    public static class DateTimeUtils
    {
        public static DateTime ToFormatedDateTime(this string manualDateTime, string format = Constantes.FormatoFecha)
        {
            if (DateTime.TryParseExact(manualDateTime, format,
                null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime;
            }
            
            throw new Exception($"Formato de fecha y hora no válido. Debe ser {format}.");
        }

        public static DateTime ToFormatedDateTime(this DateTime now)
        {
            if (!DateTime.TryParseExact(now.ToString(Constantes.FormatoFecha), Constantes.FormatoFecha,
                null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
            {
                throw new Exception($"Formato de fecha y hora no válido. Debe ser {Constantes.FormatoFecha}.");
            }

            return dateTime;
        }

        public static string ToFormatedStringDateTime(this DateTime now)
        {
            return now.ToString(Constantes.FormatoFecha);
        }
    }
}
