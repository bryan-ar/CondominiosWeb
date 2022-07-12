using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiosMQ
{
    public class Reserva
    {
        public string FechaReserva { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int IdAreaComun { get; set; }
        public int IdInquilino { get; set; }
        public int usuariocreacion { get; set; }
        public string fechacreacion { get; set; }
    }
}
