using ReservacionVuelos.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservacionVuelos.Entities
{
    public class Vuelo
    {
        public string AeropuertoOrigen { get; set; }
        public string AeropuertoDestino { get; set; }
        public AlcanceVuelo Alcance { get; set; }
        public string NumeroVuelo { get; set; }
        public DateTime FechaHoraVuelo { get; set; }

        public Vuelo() { }
        
    }

}
